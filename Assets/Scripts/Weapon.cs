using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


// this script is attached to the staff of the player.The enemy only takes damage if the player is under the correct potion effect
public class Weapon : MonoBehaviour
{
    [SerializeField] private InputPlayer inputPlayer;
    // Event to update the EnemiesLeftUI;
    public static event Action onEnemyKilled;

    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        // if there's an enemy && the player is attacking
        if(enemy != null)//inputPlayer.PoweredUp && inputPlayer.attacking
        {
            // if the player is powerUp with a potion his attacks pierce through the enemy's armor, otherwise the enemy takes 0 damage
            enemy.takingDamage = true;
            enemy.healthPoints.Damage(50);
            if (enemy.healthPoints.GetCurrentHealth == 0)
            {
                StartCoroutine(DeathSequence(enemy));
                
            }
            
            Debug.Log(enemy.healthPoints.GetCurrentHealth);

        }
    }
    public IEnumerator DeathSequence(Enemy enemy)
    {
        enemy.dead = true;
        yield return new WaitForSeconds(1f);
        enemy.gameObject.SetActive(false);
        if (onEnemyKilled != null)
        {
            onEnemyKilled.Invoke();
        }
    }
}
