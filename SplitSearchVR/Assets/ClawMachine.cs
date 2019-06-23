using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : MonoBehaviour
{
    public GameObject movingInput;

    public float dropSpeed;
    public float moveSpeed;

    private float xMax = 4;
    private float zMax = 4;


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

        float remapx = Remap(movingInput.transform.position.x);
        float remapz = Remap(movingInput.transform.position.z);

        print("Remapped x: " + remapx);
        print("Remapped z: " + remapz);

        Vector3 relativeDist = new Vector3(remapx, transform.position.y, remapz);

        transform.position = Vector3.Slerp(transform.position, relativeDist, Time.deltaTime);
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

    float Remap(float f)
    {
        f = Mathf.Clamp(f, -0.5f, 5f);
        float remappedValue = (f + 0.5f) * (8) - 4;
        return f;
    }
}
