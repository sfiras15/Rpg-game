using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the different inputs and states of the player to trigger the animations

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private KeyCode collectKey;
    [SerializeField] private KeyCode interactionKey;
    [SerializeField] private KeyCode attackKey;
    private bool collectKeyPressed;
    private bool interactionKeyPressed;
    public bool harvesting;

    public bool crafting;
    public bool attacking;

    public bool usingItem;
    private void OnEnable()
    {
        Inventory.onItemUsed += PlayerState;
    }
    private void OnDisable()
    {
        Inventory.onItemUsed -= PlayerState;
    }
    public void PlayerState()
    {
        usingItem = true;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }
        if (Input.GetKeyDown(collectKey))
        {
            collectKeyPressed = true;
        }
        else
        {
            collectKeyPressed = false;
        }
        if (Input.GetKeyDown(interactionKey))
        {
            interactionKeyPressed = true;
        }
        else
        {
            interactionKeyPressed = false;
        }
    }
    private void LateUpdate()
    {
        crafting = false;
        harvesting = false;
        usingItem = false;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collectKeyPressed)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Mushroom"))
            {
                harvesting = true;
                Inventory.instance.Add(collision.gameObject.GetComponent<Item>());
                collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Flower"))
            {
                harvesting = true;
                Inventory.instance.Add(collision.gameObject.GetComponent<Item>());
                collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
        if (interactionKeyPressed)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("CraftingTable"))
            {
                crafting = true;
            }
        }
    }
}
