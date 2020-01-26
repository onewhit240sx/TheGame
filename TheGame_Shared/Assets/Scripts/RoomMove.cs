using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class RoomMove : MonoBehaviour
{

    public Vector2 cameraChangeMaxPosition;
    public Vector2 cameraChangeMinPosition;
    public Vector3 playerChange;

    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText; 


    private CameraMovement camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            camera.minPosition = cameraChangeMinPosition;
            camera.maxPosition = cameraChangeMaxPosition;
            other.transform.position += playerChange; 

            if(needText)
            {
                StartCoroutine(placeNameCo()); 
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
