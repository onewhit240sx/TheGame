using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float MovementSpeed;
    public float NoticeRange;
    public float AttackRange;

    private Rigidbody2D mRigidBody;
    private Transform mTarget;
    private Animator mAnimator;

    private float _TargetDistance;
    private bool _isActive = true;

    // Start is called before the first frame update
    void Start() {
        mAnimator = GetComponent<Animator>();
        mTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
       _TargetDistance = Vector2.Distance(transform.position, mTarget.position);

        if (_isActive)
        {
            // Attack Target
            if (_TargetDistance < AttackRange)
            {
                Attack();
            }

            // Persuit Target
            else if (_TargetDistance < NoticeRange && _TargetDistance > AttackRange)
            {
                Pursue();
            }

            // Idle
            else if (_TargetDistance > NoticeRange)
            {
                Idle();
            }
        }
    }

    private void Attack()
    {
        mAnimator.SetBool("isAttacking", true);
    }

    private void Pursue()
    {
        mAnimator.SetBool("isAttacking", false);
        mAnimator.SetBool("isFollowing", true);
        transform.position = Vector2.MoveTowards(transform.position, mTarget.position, MovementSpeed * Time.deltaTime);
    }

    private void Idle()
    {
        foreach(AnimatorControllerParameter parameter in mAnimator.parameters)
        {
            mAnimator.SetBool(parameter.name, false);
        }
    }

    public void Hit()
    {
        mAnimator.SetTrigger("damaged");
        Debug.Log("hit");
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(.5f);
        _isActive = true;
        
    }
}
