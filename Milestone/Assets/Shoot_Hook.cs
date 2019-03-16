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
    public float speed = 15f;
    public float hookSpeed = 20f;

    public BoxCollider thisBoxCollider;

    private Camera mainCamera;

    public GameObject player;

    public AudioSource spearAudioSource;

    public Vector3 grapplePos;

    Vector3 savedLocalPosition;
    Vector3 savedLocalRotation;
    Vector3 savedLocalScale;

    public bool playerGrappleMove = false;

    //private float startTime;

	// Use this for initialization
	void Start () {
        //prefab = Resources.Load("Hook") as GameObject;
        thisRigidBody = GetComponent<Rigidbody>();
        thisTrailRenderer = GetComponent<TrailRenderer>();
        mainCamera = GetComponentInParent<Camera>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        spearAudioSource = GetComponent<AudioSource>();

        savedLocalPosition = this.transform.localPosition;
        savedLocalRotation = this.transform.localEulerAngles;
        savedLocalScale = this.transform.localScale;

        //startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //float distCovered = (Time.time - startTime) * speed;
        //float fracJourney = distCovered / grappleDis;

        float zoom = speed * Time.deltaTime;
        float hookSpeedZoom = hookSpeed * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, cameraRayDistance))
            {

                //GameObject hook = Instantiate(prefab) as GameObject;
                //hook.transform.position = transform.position + Camera.main.transform.forward * 2;
                spearAudioSource.Play();
                thisTrailRenderer.enabled = true;
                playerRigidBody.useGravity = false;
                playerRigidBody.constraints = RigidbodyConstraints.FreezeAll;
                thisRigidBody.isKinematic = false;
                //thisRigidBody.AddForce(hit.point * hookSpeed);
                transform.position = Vector3.MoveTowards(transform.position, hit.point, 100f * Time.deltaTime);
                thisBoxCollider.enabled = true;
            }
        }

        if (playerGrappleMove)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, grapplePos, zoom);
            //playerGrappleMove = false;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        //thisRigidBody.isKinematic = true;
        //thisTrailRenderer.enabled = false;
        grapplePos = transform.position;
        grappleDis = Vector3.Distance(player.transform.position, transform.position);

        thisRigidBody.constraints = RigidbodyConstraints.FreezeAll;
        transform.parent = null;

        //playerRigidBody.constraints = RigidbodyConstraints.None;
        //playerRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        playerGrappleMove = true;

        if(grappleDis < 2)
        {
            playerRigidBody.constraints = RigidbodyConstraints.None;
            playerRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            playerRigidBody.useGravity = true;

            transform.SetParent(Camera.main.transform);
            transform.localPosition = savedLocalPosition;
            transform.localEulerAngles = savedLocalRotation;
            transform.localScale = savedLocalScale;

            thisTrailRenderer.enabled = false;
            thisTrailRenderer.Clear();

            playerGrappleMove = false;
        }
    }
}
