using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        print("You season and win!");

        GameManager.Instance.SetWinCondition(true);

    }

    public void OnTriggerEnter(Collider other)
    {
        print("You season and win!");

        GameManager.Instance.SetWinCondition(true);

    }
}
