using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AutoSurferTry3 : MonoBehaviour
{
    int storeChildCount;
    void Start()
    {
        storeChildCount = this.gameObject.transform.childCount;
        for (int i = 0; i < storeChildCount; i++)
        {
            //Debug.Log(this.gameObject.transform.GetChild(i).name);
        }
    }
    bool FindClosestTargetPoints(out TargetPoint targetPoint)
    {
        targetPoint = FindObjectsOfType<TargetPoint>().Where(t => !t.isFilled).OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).FirstOrDefault();
        return targetPoint;
    }

    //void Update()
    //{
    //    for (int i = 0; i < storeChildCount; i++)
    //    {

    //    }
    //}
}
