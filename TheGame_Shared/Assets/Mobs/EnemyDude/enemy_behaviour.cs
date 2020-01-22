using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behaviour : MonoBehaviour
{
    public float mSpeed;
    private Transform mTarget;

    // Start is called before the first frame update
    void Start()
    {
        mTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mTarget.position, mSpeed * Time.deltaTime);
    }
}
