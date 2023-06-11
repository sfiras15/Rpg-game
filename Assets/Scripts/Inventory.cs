using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game Manager.Handles the inventory & the items picked up/crafted 

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    [SerializeField] public float powerUpDuration = 5f;
    [SerializeField] private ParticleSystem purpleAura;
    [SerializeField] private ParticleSystem redAura;
    [SerializeField] private ParticleSystem greenAura;
    //[SerializeField] private ParticleSystem activeAura = null;
    [SerializeField] private int inventorySize;

    public static event Action onItemChanged;
    public static event Action onItemUsed;
    
    public List<Item> items = new List<Item>();


    public void UseItem(Item item)
    {
        if (item.itemName == "PurplePotion")
        {
            DisableRedAura();
            DisableGreenAura();
            purpleAura.gameObject.SetActive(true);
            purpleAura.Play();
            Invoke(nameof(DisablePurpleAura), powerUpDuration);

        }
        else if (item.itemName == "RedPotion")
        {
            DisablePurpleAura();
            DisableGreenAura();
            redAura.gameObject.SetActive(true);
            redAura.Play();
            Invoke(nameof(DisableRedAura), powerUpDuration);
        }
        else
        {
            DisablePurpleAura();
            DisableRedAura();
            greenAura.gameObject.SetActive(true);
            greenAura.Play();
            Invoke(nameof(DisableGreenAura), powerUpDuration);  
        }
        if (onItemUsed != null)
            onItemUsed.Invoke();
        //activeAura.gameObject.SetActive(false);
        //activeAura.Pause();
    }
    private void DisablePurpleAura()
    {
        purpleAura.gameObject.SetActive(false);
        purpleAura.Pause();

    }
    private void DisableGreenAura()
    {
        greenAura.gameObject.SetActive(false);
        greenAura.Pause();

    }
    private void DisableRedAura()
    {
        redAura.gameObject.SetActive(false);
        redAura.Pause();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
       
    }
    public void Add(Item item)
    {
        if (items.Count >= inventorySize)
        {
            Debug.Log("Not enough room.");
            return;
        }

        items.Add(item);

        if (onItemChanged != null)
            onItemChanged.Invoke();
    }
    public void RemoveItem(string itemName,int amount = 1)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == itemName)
            {
                if (amount  >= 1)
                {
                    items.Remove(items[i]);
                    amount--;
                }
            }
                
        }
        

        if (onItemChanged != null)
            onItemChanged.Invoke();
    }
    public int itemAmount(Item item,string itemName)
    {
        int amount = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (item.itemName == items[i].itemName)
            {
                amount++;
            }
        }
        return amount;
    }


}
