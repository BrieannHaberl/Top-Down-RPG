using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator myAni;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    void Start()
    {
        myAni = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>=minRange)
        {
            FollowPlayer();
        }
        
    }
    public void FollowPlayer()
    {
        myAni.SetBool("isMoving", true);
        myAni.SetFloat("MoveX",  (target.position.x - transform.position.x));
        myAni.SetFloat("MoveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
