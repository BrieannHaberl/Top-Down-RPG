using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;
    public HeartManager heartManager; // Reference to the HeartManager script
    public GameObject loseScreenBlueApple; // special lose screen 
    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }


    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for(int i = 0; i < playerInventory.myInventory.Count; i++)
            {
                GameObject temp =
                    Instantiate(blankInventorySlot, 
                    inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                ItemSlot newSlot = temp.GetComponent<ItemSlot>();
                if (newSlot)
                {
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }

                
                
            }
        }
    }
    // Start is called before the first frame update


    void Start()
    {
        MakeInventorySlots();
        SetTextAndButton("", false);

    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();

            if (currentItem.itemName == "BlueApple") 
            {
                // Lose all health by calling the TakeDamage method of the HeartManager

                heartManager.TakeDamage(heartManager.maxHealth);
                loseScreenBlueApple.SetActive(true);
            }
        }
    }

}
