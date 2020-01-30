using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public float speed;
    public float idleRange;
    public float beginAttackRange;

    public Transform target;
    public Animator animator; 

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {
        if(Vector2.Distance(transform.position, target.position) < idleRange)
        {
            animator.SetBool("isFollowing", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, target.position) < beginAttackRange)
            {

            }
        }
        else
        {
            animator.SetBool("isFollowing", false);
        }
    }
}
