using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour


{
    private Rigidbody2D myRB;
    private Animator myAni;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float runSpeedMultiplier = 2f; // New variable for running speed multiplier
    [SerializeField]
    private float animationSpeedMultiplier = 2f; // New variable for animation speed multiplier
    [SerializeField]
    private float knockbackForce = 10f; // for collisions

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool IsAttacking;

    private bool isIce = false;




    public VectorValue startingPosition; // most recently added for the house 
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAni = GetComponent<Animator>();
        myRB.freezeRotation = true; // Prevent rotation
        transform.position = startingPosition.initialValue; // most recently added for the house 


    }

    void FixedUpdate()
    {
        if (isIce)
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
            myRB.AddForce(direction, ForceMode2D.Force);
        }
        else
        {
            float currentSpeed = Input.GetKey(KeyCode.K) ? speed * runSpeedMultiplier : speed;

            myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * currentSpeed * Time.fixedDeltaTime;
           // myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
            myAni.SetFloat("MoveX", myRB.velocity.x);
            myAni.SetFloat("MoveY", myRB.velocity.y);

            // Set animation playback speed based on whether the B key is held down
            myAni.speed = Input.GetKey(KeyCode.K) ? animationSpeedMultiplier : 1f;

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                myAni.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                myAni.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }

        }

    
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Calculate knockback direction away from the enemy
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            // Apply knockback force to the player
            myRB.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }
    }


    private void Update()
    {
        if (IsAttacking)
        {
            myRB.velocity = Vector2.zero; //stops the player from moving while attacking
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0 )
            {
                myAni.SetBool("IsAttacking", false);
                IsAttacking = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            attackCounter = attackTime;
            myAni.SetBool("IsAttacking", true);
            IsAttacking = true;



        }
    }




}
