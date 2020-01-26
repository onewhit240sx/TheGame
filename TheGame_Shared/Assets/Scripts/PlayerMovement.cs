using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum is like a enum but has more states not just true or false
//you can add many states.
public enum PlayerState
{
    walk,
    attack,
    interact
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Animator animator; 


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk; 
        animator = GetComponent<Animator>(); 
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1); 

      

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack )
        {
            StartCoroutine(AttackCO());
        }
        else if(currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
       

       
    }
    private IEnumerator AttackCO()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk; 
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
        change.Normalize(); 
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); 
    }

   
}
