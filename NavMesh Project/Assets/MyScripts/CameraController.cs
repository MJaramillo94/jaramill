using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float walkDistance;
    public float runDistance;
    public float height;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            Debug.LogWarning("No Target");

        myTransform = transform;

           
    }

  
    // Update is called once per frame
  

    private void LateUpdate()
    {
        myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - walkDistance);
        
    }
}
