using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Attached to the CraftingCanvas. Handles the crafting menu.

public class CraftingUI : MonoBehaviour
{
    // Reference to theses scripts under the player prefab in order to be able to click on the different elements of the UI
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private ThirdPersonController thirdPersonController;
    [SerializeField] private PlayerInput playerInput;


    [SerializeField] private InputPlayer inputPlayer;
    [SerializeField] private GameObject craftingUI;
    [SerializeField] private GameObject inventoryUI;
    private void Update()
    {
        if (inputPlayer.crafting)
        {
            if (!craftingUI.activeSelf)
            {
                starterAssetsInputs.SetCursorState(false);
                thirdPersonController.LockCameraPosition = true;
                playerInput.enabled = false;
                craftingUI.SetActive(true);
                inventoryUI.SetActive(true);
                inventoryUI.GetComponentInParent<InventoryUI>().UpdateUI();
            }
            else
            {
                starterAssetsInputs.SetCursorState(true);
                thirdPersonController.LockCameraPosition = false;
                playerInput.enabled = true;
                craftingUI.SetActive(false);
                inventoryUI.SetActive(false);
            }

        }
    }
}
