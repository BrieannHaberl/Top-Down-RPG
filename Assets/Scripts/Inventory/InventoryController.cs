using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Reference to the InventoryPanel GameObject in the hierarchy
    public GameObject inventoryPanel;

    // Boolean to keep track of whether the inventory is currently active or not
    private bool isInventoryActive = false;

    void Start()
    {
        // Ensure the inventory panel is initially deactivated
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        // Check for the I key press
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Toggle the inventory panel's visibility
            ToggleInventoryPanel();
        }
    }

    // Method to toggle the inventory panel's visibility
    private void ToggleInventoryPanel()
    {
        // If the inventory is currently active, deactivate it
        if (isInventoryActive)
        {
            inventoryPanel.SetActive(false);
            isInventoryActive = false;
        }
        else
        {
            // If the inventory is currently inactive, activate it
            inventoryPanel.SetActive(true);
            isInventoryActive = true;
        }
    }
}
