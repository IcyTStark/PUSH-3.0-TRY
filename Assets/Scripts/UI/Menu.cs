using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Camera cam;
    GameObject LevelText;

    
    private void Start()
    {
        
    }
    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
        {
            cam = Camera.main;
            cam.GetComponent<TouchScript>().canClick = false;
            LevelText = GameObject.Find("Canvas").transform.GetChild(2).gameObject;

            if (this.gameObject.activeInHierarchy == true)
            {
                LevelText.SetActive(false);
                cam.fieldOfView = 90f;
            }
        }
    }
}
