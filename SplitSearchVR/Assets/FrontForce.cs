using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontForce : MonoBehaviour
{
    public float forceMult = 200;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * forceMult * Time.deltaTime);
        
    }

}
