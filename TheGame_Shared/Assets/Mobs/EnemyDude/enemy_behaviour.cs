using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public float mSpeed;
    private Transform mTarget;
    private Vector2 change;
    public CircleCollider2D attackRange;

   
    

    public Animator animator; 


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attackRange = GetComponent<CircleCollider2D>(); 

       
        mTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector2.zero;
        transform.position = Vector2.MoveTowards(transform.position, mTarget.position, mSpeed * Time.deltaTime);
        change.x = transform.position.x - mTarget.position.x;
        change.y = transform.position.y - mTarget.position.y; 
        
    
        

        //makes the enemy move by changeing the boolean in the animator to true
        if(change != Vector2.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true); 

        }
        else
        {
            animator.SetBool("moving",false); 
        }
        

    }

    private void OnTriggerEnter2D(CircleCollider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            animator.SetTrigger("New Triger"); 
        }


    }
}
