using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurferSlots : MonoBehaviour
{
    public int slotIndex;
    public Vector3 slotPosition;

    public bool isFilled = false;
    
    void Start()
    {
        isFilled = false;
    }
}
