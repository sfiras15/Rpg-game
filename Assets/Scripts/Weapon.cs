using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;


// this script is attached to the staff of the player.The enemy only takes damage if the player is under the correct potion effect
public class Weapon : MonoBehaviour
{
    [SerializeField] private InputPlayer inputPlayer;

    [SerializeField] BoxCollider m_Collider;
    // Event to update the EnemiesLeftUI;
    public static event Action onEnemyKilled;



    private void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy != null)//inputPlayer.PoweredUp && inputPlayer.attacking
        {
            m_Collider.enabled = false;
            if (inputPlayer.poweredUp)
            {
                enemy.takingDamage = true;
                enemy.healthPoints.Damage(50);
            }
            else
            {
                enemy.takingDamage = false;
                enemy.healthPoints.Damage(0);
            }
            
            if (enemy.healthPoints.GetCurrentHealth == 0)
            {
                StartCoroutine(DeathSequence(enemy));

            }
        }
    }
    public IEnumerator DeathSequence(Enemy enemy)
    {
        yield return new WaitForSeconds(0.5f);
        enemy.dead = true;
        enemy.GetComponent<EnemyPatrol>().enabled = false;
        enemy.GetComponent<BoxCollider>().enabled = false;
        enemy.GetComponent<NavMeshAgent>().enabled = false;
        enemy.GetComponent<RandomMovement>().enabled = false;
        enemy.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(1f);
        enemy.gameObject.SetActive(false);
        if (onEnemyKilled != null)
        {
            onEnemyKilled.Invoke();
        }
    }
}
