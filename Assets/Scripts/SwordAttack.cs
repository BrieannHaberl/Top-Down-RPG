using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Breakable") 
        {
            EnemyHealth healthManager;
            healthManager = other.gameObject.GetComponent<EnemyHealth>();
            healthManager.HurtEnemy(damage);
        }
        
    }
}
