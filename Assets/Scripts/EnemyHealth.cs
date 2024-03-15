using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int curentHealth;
    public int maxHealth;

    public bool flashOn;
    [SerializeField]
    private float flashDuration = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
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
            Destroy(gameObject);
        }
    }
}
