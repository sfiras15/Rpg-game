using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Handles the animation of the Enemy based on its various states

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.takingDamage)
        {
            animator.SetBool("TakeDamage", true);
        }
        else
        {
            animator.SetBool("TakeDamage", false);
        }
        if (enemy.dead)
        {
            animator.SetTrigger("Die");
        }
        animator.SetTrigger("Walk Forward");
    }
}
