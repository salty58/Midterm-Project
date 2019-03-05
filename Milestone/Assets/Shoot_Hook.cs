using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Hook : MonoBehaviour {

    //GameObject prefab;

    public Rigidbody thisRigidBody;
    private Rigidbody playerRigidBody;

    public TrailRenderer thisTrailRenderer;

    public float velocityModifier;
    public float cameraRayDistance = 1000f;
    public float grappleDis;

    public BoxCollider thisBoxCollider;

    private Camera mainCamera;

    public GameObject player;

    public Vector3 grapplePos;

	// Use this for initialization
	void Start () {
        //prefab = Resources.Load("Hook") as GameObject;
        thisRigidBody = GetComponent<Rigidbody>();
        thisTrailRenderer = GetComponent<TrailRenderer>();
        mainCamera = GetComponentInParent<Camera>();
        playerRigidBody = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit, cameraRayDistance))
            {

                //GameObject hook = Instantiate(prefab) as GameObject;
                //hook.transform.position = transform.position + Camera.main.transform.forward * 2;
                playerRigidBody.constraints = RigidbodyConstraints.FreezeAll;
                thisRigidBody.isKinematic = false;
                thisRigidBody.AddForce(hit.point + transform.forward * velocityModifier);
                thisTrailRenderer.enabled = true;
                thisBoxCollider.enabled = true;
            }
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        //thisRigidBody.isKinematic = true;
        thisTrailRenderer.enabled = false;
        grapplePos = transform.position;
        grappleDis = Vector3.Distance(player.transform.position, transform.position);

        thisRigidBody.constraints = RigidbodyConstraints.FreezeAll;
        transform.parent = null;

        playerRigidBody.constraints = RigidbodyConstraints.None;
        playerRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        player.transform.position = Vector3.MoveTowards(player.transform.position, grapplePos, grappleDis - 1);
    }
}
