using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// attached to each recipe gameObject in order to properly craft and add the potions to the inventory

public class CraftingRecipe : MonoBehaviour
{
    [SerializeField] private Image firstIngrediantsIcon;
    [SerializeField] private Image secondIngrediantsIcon;
    [SerializeField] private Image iconResult;
    [SerializeField] private Item firstIngrediant;
    [SerializeField] private int firstIngrediantAmountNeeded;
    [SerializeField] private Item secondIngrediant;
    [SerializeField] private int secondIngrediantAmountNeeded;
    [SerializeField] private Item itemResult;
    private void Start()
    {
        AddRecipe();
    }
    public void CraftPotion()
    {
        if (Inventory.instance.itemAmount(firstIngrediant) >= firstIngrediantAmountNeeded &&
            Inventory.instance.itemAmount(secondIngrediant) >= secondIngrediantAmountNeeded)
        {   
            Inventory.instance.RemoveItem(firstIngrediant,firstIngrediant.name);
            Inventory.instance.RemoveItem(secondIngrediant,secondIngrediant.name);
            Inventory.instance.Add(itemResult);
            Debug.Log("crafted");
        }    
    }
    public void AddRecipe()
    {
        firstIngrediantsIcon.sprite = firstIngrediant.itemIcon;
        secondIngrediantsIcon.sprite = secondIngrediant.itemIcon;
        iconResult.sprite = itemResult.itemIcon;
    }
}
