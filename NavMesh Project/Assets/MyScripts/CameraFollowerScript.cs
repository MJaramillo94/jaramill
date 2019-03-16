using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowerScript : MonoBehaviour
{
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    void Update()
    {
        if (Cursor.visible == true)
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = new float();

                if (transform.parent != null && transform.parent.CompareTag("Player") == true)
                {
                    rotationX = transform.parent.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                    transform.parent.transform.localEulerAngles = new Vector3(0, rotationX, 0);
                    transform.localEulerAngles = new Vector3(-rotationY, 0, 0);

                }
                else if (transform.parent != null)
                {
                    rotationX = transform.parent.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                   //rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                   // rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                    transform.parent.transform.localEulerAngles = new Vector3(0, rotationX, 0);
                    transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                }
                
                else {
                    rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                  //  rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                   // rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

                    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                }
                
            }
            else if (axes == RotationAxes.MouseX)
            {
                if (transform.parent != null)
                {
                    transform.parent.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                }
                else
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                }
            }
            else
            {
              //  rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
              //  rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
    }
}