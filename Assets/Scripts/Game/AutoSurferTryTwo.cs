using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSurferTryTwo : MonoBehaviour
{
    public GameObject[] TargetPointsInScene;
    public List<TargetPoint> TargetPointScriptOfTargetPoints;
    Vector3 targetPosition;

    public float speed;

    //1. Find all Target Points In Scene

    //2. After finding find the difference 
    void Start()
    {
        //1. Find all Target Points In Scene
        TargetPointsInScene = GameObject.FindGameObjectsWithTag("TargetPoint");

       foreach(GameObject tp in TargetPointsInScene)
       {
            TargetPoint storeTargetPointScript = tp.GetComponent<TargetPoint>();
            TargetPointScriptOfTargetPoints.Add(storeTargetPointScript);
       }


    }
    private void Update()
    {
        //for (int i = 0; i < TargetPointsInScene.Length; i++)
        //{
        //}
    }
}
