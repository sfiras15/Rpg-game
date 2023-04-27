using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the animation of the player based on its various states
public class Animation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private InputPlayer inputPlayer;

    // Update is called once per frame
    void Update()
    {

        if (inputPlayer.attacking)
        {
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false);
        }

        if (inputPlayer.crafting)
        {
            animator.SetBool("Crafting", true);
        }
        else
        {
            animator.SetBool("Crafting", false);
        }
        if (inputPlayer.harvesting)
        {
            animator.SetBool("Harvesting", true);
        }
        else
        {
            animator.SetBool("Harvesting", false);
        }

        if (inputPlayer.usingItem)
        {
            animator.SetBool("UsingItem", true);
        }
        else
        {
            animator.SetBool("UsingItem", false);
        }
    }
}
