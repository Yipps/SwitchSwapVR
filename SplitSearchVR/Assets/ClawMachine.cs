using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : MonoBehaviour
{
    public float dropSpeed;
    public float moveSpeed;

    public bool hasGrabbed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            print("space");
            DropCrane();
        }
    }

    IEnumerator DropCraneCoroutine()
    {
        while (true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * dropSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasGrabbed)
        {
            hasGrabbed = true;
            //other.attachedRigidbody.isKinematic = true;
            other.transform.parent = transform;
            print("Grabbed " + other.name);

            StopAllCoroutines();

            RaiseCrane();
            
            
        }
        
    }

    public void DropCrane()
    {
        StartCoroutine(DropCraneCoroutine());

    }

    public void RaiseCrane()
    {
        StartCoroutine(RaiseCraneCoroutine());
    }

    IEnumerator RaiseCraneCoroutine()
    {
        while (true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * dropSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}
