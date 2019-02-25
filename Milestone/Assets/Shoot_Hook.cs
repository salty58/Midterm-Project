using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Hook : MonoBehaviour {

    //GameObject prefab;

    public Rigidbody thisRigidBody;

    public TrailRenderer thisTrailRenderer;

    public float velocityModifier;

	// Use this for initialization
	void Start () {
        //prefab = Resources.Load("Hook") as GameObject;
        thisRigidBody = GetComponent<Rigidbody>();
        thisTrailRenderer = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //GameObject hook = Instantiate(prefab) as GameObject;
            //hook.transform.position = transform.position + Camera.main.transform.forward * 2;
            thisRigidBody.isKinematic = false;
            thisRigidBody.AddForce(transform.position + Camera.main.transform.forward * velocityModifier);
            thisTrailRenderer.enabled = true;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        thisRigidBody.isKinematic = true;
        transform.parent = null;
    }
}
