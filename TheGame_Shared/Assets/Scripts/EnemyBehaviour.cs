using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float MovementSpeed;
    public float AttackSpeed;
    public float NoticeRange;
    public float AttackRange;

    public Rigidbody2D mRigidBody;
    public Transform mTarget;
    public Animator mAnimator;

    private bool _isDiving = false;
    private float _TargetDistance;

    // Start is called before the first frame update
    void Start() {
        mAnimator = GetComponent<Animator>();
        mTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
       _TargetDistance = Vector2.Distance(transform.position, mTarget.position);

        // Attack Target
        if(_TargetDistance < AttackRange)
        {
            Attack();
        } 

        // Persuit Target
        else if(_TargetDistance < NoticeRange && _TargetDistance > AttackRange) 
        {
            Pursue();
        }

        // Idle
        else
        {
            Idle();
        }
    }

    private void Attack()
    {
        if (_isDiving)
        {
            mAnimator.SetBool("isDiving", true);
            Dive();
        }
        else
        {
            _isDiving = true;
            mAnimator.SetBool("isDiving", false);
            // get into dive position
        }
    }

    private void Dive()
    {
        int framePosition = Time.frameCount % 3;

        if (_TargetDistance == 0)
        {
            mAnimator.SetBool("isAttacking", true);
        }
        else
        {
            mAnimator.SetBool("isAttacking", false);
            if (framePosition == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, mTarget.position, (AttackSpeed) * Time.deltaTime);
            }
        }
    }

    private void Pursue()
    {
        mAnimator.SetBool("isDiving", false);
        mAnimator.SetBool("isFollowing", true);
        transform.position = Vector2.MoveTowards(transform.position, mTarget.position, MovementSpeed * Time.deltaTime);
    }

    private void Idle()
    {
        mAnimator.SetBool("isDiving", false);
        mAnimator.SetBool("isFollowing", false);
    }
}
