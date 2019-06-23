using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinataDetector : MonoBehaviour
{
    public PinataSceneManager _SceneManager;
    public Material _Mat;

    private MeshRenderer renderer;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("Pinata Hit");
            _SceneManager.OnSuccess();
            renderer.material = _Mat;
        }
    }
}
