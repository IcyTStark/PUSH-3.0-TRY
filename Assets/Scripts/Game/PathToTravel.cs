using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

//To Assign surfer its goal Location
public class PathToTravel : MonoBehaviour
{
    //Config Params
    [Header("Surfers WayPoints & Speed")]
    [SerializeField] public List<TargetPoint> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    [HideInInspector] public Vector3 targetPosition;

    [Space]
    [Header("Audio & Particles")]
    AudioSource audioSource;
    [SerializeField] AudioClip[] surferSounds;
    [SerializeField] GameObject particleToPlay;

    //Control State Variables
    [HideInInspector]
    public bool move = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Get reference of the AudioSource
        transform.position = this.transform.position;
    }

    void FixedUpdate()
    {
        if (move == true) //if only move is true then Do these. Move gets true through TouchScript when playerClick.
        {
            MoveTarget();
        }
    }

    void MoveTarget()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            targetPosition = waypoints[waypointIndex].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                if (waypoints[waypointIndex].isFilled == false)
                {
                    waypoints[waypointIndex].isFilled = true;
                    #region Playing Audio & Particles
                    AudioClip clip = surferSounds[UnityEngine.Random.Range(0, surferSounds.Length)];
                    var storeToDestroy = Instantiate(particleToPlay, targetPosition, Quaternion.identity);
                    Destroy(storeToDestroy, 5f);
                    audioSource.PlayOneShot(clip);
                    #endregion 
                    move = false;
                }
                else if (waypoints[waypointIndex].isFilled == true)
                {
                    waypointIndex++;
                    targetPosition = waypoints[waypointIndex].transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                }
            }
        }
    }
}