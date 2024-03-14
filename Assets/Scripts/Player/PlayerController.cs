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
            myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
            myAni.SetFloat("MoveX", myRB.velocity.x);
            myAni.SetFloat("MoveY", myRB.velocity.y);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                myAni.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                myAni.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }

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
        if (Input.GetKeyDown(KeyCode.N))
        {
            attackCounter = attackTime;
            myAni.SetBool("IsAttacking", true);
            IsAttacking = true;



        }
    }


    // Use Time.fixedDeltaTime for physics calculations in FixedUpdate
    //myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
    //myAni.SetFloat("MoveX", myRB.velocity.x);
    //myAni.SetFloat("MoveY", myRB.velocity.y);
    //myRB.AddForce(myRB.velocity, ForceMode2D.Force);


}
