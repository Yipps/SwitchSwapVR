using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopShaker : MonoBehaviour
{
    public Transform _Hand;

    public Vector3 deltaHand;
    public Vector3 LastHandPosition;
    public float totalHandMovement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deltaHand = LastHandPosition - _Hand.transform.localPosition;
        totalHandMovement += deltaHand.magnitude;

        LastHandPosition = _Hand.transform.localPosition;
    }
}
