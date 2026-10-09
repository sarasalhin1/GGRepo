using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Target; //The target (aka Player)
    public float Cameraspeed; //How fast the camera reaches the target

    //Determine the minimum and maximum values in both directions where the camera can move. This is to stop it 
    //from showing game edges or things you don't want to appear to the user
    public float minX, maxX;
    public float minY, maxY;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if(Target!=null)
        {
            //Calculate where the camera's new position must be 
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime*Cameraspeed);
            
            //Checks that the camera's new position is still WITHIN boundaries you set for it 
            //(e.g. camera must always be between x values 0 and 1000, and between y values -10 and 20. Depends on your game.)
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);

            //Now update the camera's position
            transform.position = new Vector3(ClampX, ClampY, -10f);
            
        }
        
    }
}
