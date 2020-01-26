using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Animator animator; 


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        myRigidbody = GetComponent<Rigidbody2D>(); 

      

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        PlayerAttack(); 

       
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharactor();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);

        }
    }
    void MoveCharactor()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); 
    }

    void PlayerAttack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attacking", true);
        }
        else
        {
            animator.SetBool("Attacking", false); 
        }
    }
}
