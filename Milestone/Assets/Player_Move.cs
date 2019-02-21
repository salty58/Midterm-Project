using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public Rigidbody myRigidBody;

    public Vector2 vectorInput;

    public float forceMultiplier;
    public float torqueMultiplier;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        vectorInput = new Vector2(inputHorizontal, inputVertical);
	}
}
