using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera Cam; //Will use this to GetComponent
	private float ScrollData; //Float collected upon mouse scrolling
	public float ZoomSpeed; //Speed of zooming in or out
	public float TargetZoom; //The value of Zoom I want by manipulating Camera size
    private float UpperLimit; //The most zoomed out you can get
    private float LowerLimit; //The most zoomed in you can get
	
	// Use this for initialization
	void Start () {
		Cam = GetComponent<Camera>();
        UpperLimit = 4;
        LowerLimit = 2;
		TargetZoom = Cam.orthographicSize; //The game will begin with TargetZoom being assigned the default given Camera size
	}
	
	// Update is called once per frame
	void Update () {
		
		//When the Mouse is still, this function returns 0. Forward scrolling returns a +ve value, backward scrolling returns -ve value
		ScrollData = Input.GetAxis("Mouse ScrollWheel");
		TargetZoom = TargetZoom - ScrollData;
        
        //As we zoom, the clamp function will make sure we stay within the boundaries of 2 and 4
		TargetZoom = Mathf.Clamp(TargetZoom, LowerLimit, UpperLimit);

		Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, TargetZoom, Time.deltaTime*ZoomSpeed);
	}
}
