using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public float speed;
    public float idleRange;
    public float diveRange;

    public Rigidbody2D rigidBody;
    public Transform target;
    public Animator animator; 

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if(Vector2.Distance(transform.position, target.position) < idleRange)
        {
            animator.SetBool("isFollowing", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target.position) < diveRange)
            {
                animator.SetBool("isStriking", true);

                if (Vector2.Distance(transform.position, target.position) == 0)
                {
                    // TODO: ADD MOB ATTACK
                }
            }
            else
            {
                animator.SetBool("isStriking", false);
            }
        }
        else
        {
            animator.SetBool("isFollowing", false);
        }
    }

    public void KnockBack()
    {
        Debug.Log("Hit");

        animator.SetBool("isStriking", false);
        animator.SetBool("isFollowing", false);
        StartCoroutine(getThrown());
        rigidBody.AddForce(transform.forward * 500, ForceMode2D.Impulse);

    }

    IEnumerator getThrown()
    {
        yield return new WaitForSeconds(.3f);
    }
}
