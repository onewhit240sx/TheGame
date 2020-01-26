using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //camera variables so we can stop it from going out side the tile map
    public Vector2 maxPosition;
    public Vector2 minPosition; 

    //smothing- for the camera moving with carector
    //target sets the a target for the camera to follow 
    public Transform target;
    public float smoothing; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y); 

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

        }
    }
}
