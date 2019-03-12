﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_FP : MonoBehaviour {

    public Rigidbody thisRigidBody; // the rigidbody we'll be moving
    public Camera thisCamera;   // the camera

    public float pitch; // the mouse movement up/down
    public float yaw;   // the mouse movement left/right

    public float fpForwardBackward; // input float from  W and S keys
    public float fpStrafe;  // input float from A D keys

    public Vector3 inputVelocity;  // cumulative velocity to move character

    public float velocityModifier;  // velocity of conroller multiplied by this number

    //public float pitchMin;
    //public float pitchMax;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        yaw = Input.GetAxis("Mouse X");
        transform.Rotate(0, yaw, 0);

        pitch = Input.GetAxis("Mouse Y");
        thisCamera.transform.Rotate(-pitch, 0, 0);
        //thisCamera.transform.rotation = new Vector3(Mathf.Clamp(thisCamera.transform.rotation.x, pitchMin, pitchMax));

        fpForwardBackward = Input.GetAxis("Vertical");
        fpStrafe = Input.GetAxis("Horizontal");

        inputVelocity = transform.forward * fpForwardBackward;
        inputVelocity += transform.right * fpStrafe;

        
    }

    void FixedUpdate()
    {
        thisRigidBody.velocity = inputVelocity * velocityModifier; // + (Physics.gravity * .69f);
    }
}
