using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public float forceMult = 200;
    private Rigidbody rb;
    public GameObject cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.right * forceMult);

    }
}
