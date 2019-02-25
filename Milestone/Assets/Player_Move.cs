using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public Rigidbody myRigidBody;

    public Vector2 vectorInput;

    public float tankVelocity;
    public float forceMultiplier;
    public float torqueMultiplier;
    public float inputToTorque;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        vectorInput.y = Input.GetAxis("Vertical");
        vectorInput.x = Input.GetAxis("Horizontal");

        //vectorInput = new Vector2(inputHorizontal, inputVertical);
        inputToTorque = vectorInput.x;
	}

    void FixedUpdate()
    {
        tankVelocity = myRigidBody.velocity.magnitude;

        if(myRigidBody.velocity.magnitude < 8f)
        {
            myRigidBody.AddForce(transform.forward * vectorInput.y * forceMultiplier, ForceMode.Impulse);
        }

        myRigidBody.AddTorque(0, inputToTorque * torqueMultiplier, 0, ForceMode.VelocityChange);
    }
}
