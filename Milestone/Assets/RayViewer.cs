using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayViewer : MonoBehaviour {

    public float cameraRayDistance = 1000f;

    public Camera mainCamera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 lineOrigin = mainCamera.transform.position;

        Debug.DrawRay(lineOrigin, mainCamera.transform.forward * cameraRayDistance, Color.red);
    }
}
