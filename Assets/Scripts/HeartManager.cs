using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Add this namespace for scene management
using System.Collections.Generic;
using System.Collections;

public class HeartManager : MonoBehaviour
{
    public int maxHealth = 8;
    private int currentHealth;
    public Image heartPrefab;
    public Transform heartsParent;
    private List<Image> hearts = new List<Image>();
    public GameObject loseScreen;
    public GameObject loseScreenBlueApple;
    //public GameObject removeLastHeart; // added to remove last heart when health reachs 0
    public float delayBeforeMenuLoad = 3f; // Time to wait before loading the menu scene

 

    void Start()
    {
        currentHealth = maxHealth;
        InitializeHearts();
    }

    void InitializeHearts()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            Image heartInstance = Instantiate(heartPrefab, heartsParent);
            hearts.Add(heartInstance);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();

        if (currentHealth <= 0)
        {
            // Player has lost, activate the lose screen
            loseScreen.SetActive(true);
            // Start coroutine to delay before loading the menu scene
            StartCoroutine(LoadMenuSceneAfterDelay());
        }


    }

    IEnumerator LoadMenuSceneAfterDelay()
    {
        // Wait for the specified delay before loading the menu scene
        yield return new WaitForSeconds(delayBeforeMenuLoad);
        // Load the menu scene
        SceneManager.LoadScene("TitleScreen");
    }

    void UpdateHearts()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
