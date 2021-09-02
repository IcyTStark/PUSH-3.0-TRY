using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class FindYourWay : MonoBehaviour
{
    void Update()
    {
        float distanceToClosestPoint = Mathf.Infinity;
        TargetPoint closestPoint = null;
        TargetPoint[] allTargetPoints = GameObject.FindObjectsOfType<TargetPoint>();

        foreach (TargetPoint tp in allTargetPoints)
        {
            float distanceToTargetPoint = (tp.transform.position - this.transform.position).sqrMagnitude;
            closestPoint = tp;
            if (distanceToTargetPoint < distanceToClosestPoint)
            {
                distanceToClosestPoint = distanceToTargetPoint;
                transform.position = Vector3.MoveTowards(this.transform.position, closestPoint.transform.position, .5f * Time.deltaTime);
                
            }
        }
    }
}
