using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyController : MonoBehaviour
{

    public GameObject flappy;
    public Rigidbody rb;
    public float forceMult = 10;
    int keyPressed = 0;
    public float jumpStrength;
    public float gravityFactor;
    //private float verticalInput;


    //Controller position
    public Transform _Hand;



    //The minimum amount of shaking force to count as a shake
    public float flapForceMin;

    //The change in soda position from last frame to current frame
    private Vector3 deltaFlapPosition;

    //Last frame's soda position
    private Vector3 LastFlapPosition;

    private bool hasGottenRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rb = flappy.GetComponent<Rigidbody>();
        StartCoroutine(WaitForVRTK());
    }

    // Update is called once per frame
    void Update()
    {
        //Change in soda positions between last frame and current frame
        deltaFlapPosition = LastFlapPosition - _Hand.transform.position;
        //Debug.Log(rb.velocity);
        //if (hasGottenRigidBody)
        //{
        //    //Debug.Log("i hsve s rigid body");
        //    //rb.AddForce(Vector3.right * forceMult);
        //    //rb.AddForce(Vector3.up * forceMult);
        //    print(deltaFlapPosition.magnitude);
        //    if (deltaFlapPosition.magnitude > flapForceMin){

        //        rb.AddForce(Vector3.up * jumpStrength);
        //    }
        //   // rb.AddForce(-Vector3.up * gravityFactor);

        //}
        if (deltaFlapPosition.magnitude > flapForceMin)
        {

            rb.transform.Translate(Vector3.up*Time.deltaTime*jumpStrength);
        }
        rb.transform.Translate(Vector3.right*Time.deltaTime*4);
        LastFlapPosition = _Hand.transform.position;
    }

    IEnumerator WaitForVRTK()
    {
        yield return new WaitForSeconds(1f);
        rb = flappy.GetComponent<Rigidbody>();
        hasGottenRigidBody = true;

        rb.freezeRotation = true;
        rb.mass = 1;
        //rb.AddForce(Vector3.right * forceMult);
    }
}
