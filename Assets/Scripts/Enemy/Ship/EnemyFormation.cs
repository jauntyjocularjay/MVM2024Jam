
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyFormation : MonoBehaviour
{
    private Transform txform;
    public PlayerData playerData;
    public float distanceToMaintain = 4.0f;
    public Vector3 vectorFromPlayerToThis;
    public List<SplineContainer> splines;

    void Start()
    {
        txform = GetComponent<Transform>();
    }
    void Update()
    {}
    void FixedUpdate()
    {
        vectorFromPlayerToThis = GetVectorFromPlayerToThis();
        FallBack();
    }
    private Vector3 GetVectorFromPlayerToThis()
    {
        // GetVectorFromPlayerToThis is the distance on the x and y planes respectively. It cannot be used to calculate distance
        return new Vector3
        (
            txform.position.x - playerData.position.x,
            txform.position.y - playerData.position.y
        );
    }
    private bool PlayerIsTooClose()
    {
        if(GetVectorFromPlayerToThis().magnitude <= distanceToMaintain)
        {
            // Debug.Log("Player is getting closer");
            return true;
        }
        else
        {
            return false;
        }
    }
    private void FallBack()
    {
        Vector3 angleOfApproach = GetVectorFromPlayerToThis().normalized;
        Vector3 endPosition = new Vector3
        (
            angleOfApproach.x <= 0.0f && PlayerIsTooClose()
                ? txform.position.x + 2.0f
                : txform.position.x,
            angleOfApproach.y <= 0.0f && PlayerIsTooClose()
                ? txform.position.y + 2.0f
                : txform.position.y
        );
        // Debug.Log($"endPosition: {endPosition}");
    }
}
