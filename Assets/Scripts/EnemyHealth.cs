using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int curentHealth;
    public int maxHealth;
    public bool isBoss; // trigger for win screen
    public GameObject winScreen;
    public GameObject hideHearts; // for hiding the hearts after we win


    public bool flashOn;
    [SerializeField]
    private float flashDuration = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
   // private Rigidbody2D rb; // added for knockback
   // public float knockbackForce = 10f;

    public float delayBeforeMenuLoad = 3f; // Time to wait before loading the menu scene

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
      //  rb = GetComponent<Rigidbody2D>(); //get rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if (flashCounter > flashDuration *.99f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else if (flashCounter > flashDuration * .82f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
        }
        else if (flashCounter > flashDuration * .66f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else if (flashCounter > flashDuration * .49f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
        }
        else if (flashCounter > flashDuration * .33f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else if (flashCounter > flashDuration * .16f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
        }
        else if (flashCounter > 0f)
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
        }
        else
        {
            enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            flashOn = false;
        }
        flashCounter -= Time.deltaTime;
    }


    public void HurtEnemy(int damage)
    {
        
        curentHealth -= damage;
        flashOn = true; 
        flashCounter = flashDuration;
        if (curentHealth <= 0)
        {
            if (isBoss)
            {
                winScreen.SetActive(true);
                StartCoroutine(LoadMenuSceneAfterDelay());
                Destroy(gameObject);
                hideHearts.SetActive(false);

            }
            else
            {
                Destroy(gameObject); // regular enemies
            }
            
        }
       // Vector2 knockbackDirection = (transform.position - PlayerController.instance.transform.position).normalized;
        // rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    IEnumerator LoadMenuSceneAfterDelay()
    {
        // Wait for the specified delay before loading the menu scene
        yield return new WaitForSeconds(delayBeforeMenuLoad);
        // Load the menu scene
        SceneManager.LoadScene("TitleScreen");
    }

}
