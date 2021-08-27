using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuRef;
    LevelLoadScript levelLoaderRef;
    private void Awake()
    {
        DontDestroyOnLoad(MenuRef);

    }
    private void Start()
    {
        levelLoaderRef = GetComponent<LevelLoadScript>();
        levelLoaderRef.LoadNextLevel();
    }
}
