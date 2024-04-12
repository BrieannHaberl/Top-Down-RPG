using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleDialog : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string[] dialogs; // Array to store multiple dialogs
    public bool playerInRange;

    private int interactionCounter = 0; // Counter for interactions

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && playerInRange)
        {
            // Toggle visibility of dialogBox
            dialogBox.SetActive(!dialogBox.activeInHierarchy);

            if (dialogBox.activeInHierarchy)
            {
                // Display the current dialog based on the counter
                dialogText.text = dialogs[interactionCounter % dialogs.Length];
                // Increase the interaction counter
                interactionCounter++;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
