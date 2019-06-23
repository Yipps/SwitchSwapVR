using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVStaticGameManager : MicroScene
{
    public Transform _RightHand;
    public Transform _AntennaOrigin;
    public LineRenderer _AntennaLine;
    public Material _StaticMaterial;
    private Vector3 correctDirection;
    private Vector3 currentDirection;
    private float currentDirectionComparision;

    public void StartStatic()
    {
        correctDirection = new Vector3(Random.Range(-1, 1),Random.Range(0,0.5f), 1);
        _StaticMaterial.SetColor("_ColorB", Color.black);
    }

    // Update is called once per frame
    void Update()
    {
        currentDirection = (_RightHand.position - _AntennaOrigin.position).normalized;
        _AntennaLine.SetPosition(0, _AntennaOrigin.position);
        _AntennaLine.SetPosition(1, _AntennaOrigin.position+currentDirection);
        currentDirectionComparision= Vector3.Dot(currentDirection, correctDirection);
        _StaticMaterial.SetColor("_ColorB", Color.Lerp(Color.black,Color.white, currentDirectionComparision));
        if (currentDirectionComparision > 0.90f && currentDirectionComparision < 1.1f)
        {
            GameManager.Instance.SetWinCondition(true);
        }
        Debug.DrawRay(_AntennaOrigin.position, _AntennaOrigin.position+correctDirection);
    }
}
