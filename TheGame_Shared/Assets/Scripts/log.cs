using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    sleep,
    wakeUp,
    Walking
}
public class log : Enemy
{
    public EnemyState currentState;
    public Transform target;
    public float chaseRadious;
    public float attackRadious;
    public Transform homePosition;
    public Animator animator; 

    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        currentState = EnemyState.sleep;
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistnace();
      
    }

    void CheckDistnace()
    {
       
        if(Vector3.Distance(target.position, transform.position) <= chaseRadious &&
                Vector3.Distance(target.position,transform.position ) > attackRadious)
        {
            if(currentState != EnemyState.Walking)
            {
                StartCoroutine(WakeUpCo()); 
            }
            //yield return new WaitForSeconds(.3f); 
            if(currentState == EnemyState.Walking)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); 

            }
            
        }
        else
        {
            currentState = EnemyState.sleep;
            animator.SetBool("wakeUp", false); 
        }

    }

    private IEnumerator WakeUpCo()
    {
        animator.SetBool("wakeUp", true);
        currentState = EnemyState.wakeUp;
        yield return new WaitForSeconds(1f);
        currentState = EnemyState.Walking; 
    }
}
