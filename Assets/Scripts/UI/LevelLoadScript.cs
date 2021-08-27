using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Main Script for the Entire GameUI Flow - Takes care of loading Levels
public class LevelLoadScript : MonoBehaviour
{
    private int sceneToContinue; //Gets the PlayerPrefs Saved Scene

    public GameObject menuRef;

    GameObject nextLevelUI;
    GameObject loseLevelUI;

    GameObject levelLoaderRef;
    GameObject getLevelNumberRef;


    void Start()
    {
        menuRef = GameObject.Find("Menu");
        menuRef = FindInActiveObjectByName("Menu");
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject storeCanvas = GameObject.Find("Canvas");
            getLevelNumberRef = storeCanvas.transform.GetChild(2).gameObject;
            string storeLevel = SceneManager.GetActiveScene().buildIndex.ToString();
            getLevelNumberRef.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = storeLevel;
            levelLoaderRef = GameObject.Find("LevelLoader");
            nextLevelUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            loseLevelUI = GameObject.Find("Canvas").transform.GetChild(1).gameObject;
        }
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
    }
    
    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    //Play Button Functionality
    public void play()
    {
        menuRef.SetActive(false);
        getLevelNumberRef.SetActive(true);
        Camera.main.GetComponent<TouchScript>().canClick = true;
    }
    private void Update()
    {
        CameraPanPosition();
    }

    private void CameraPanPosition()
    {
        if (Camera.main.fieldOfView > 60f)
        {
            Camera.main.fieldOfView -= 40f * Time.deltaTime;
        }
    }

    //Loads Next Level
    public void LoadNextLevel()  
    {
        if (sceneToContinue == SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.DeleteAll();    //When This happens it deletes all the PLayerPrefs for the player to start a New Game
        }
        NextSceneLoader();    //Loads the next Scene according to the index value
    }

    //Home Button Functionality
    public void LoadMainMenu()
    {
        nextLevelUI.SetActive(false);
        levelLoaderRef.GetComponent<LevelLoadScript>().LoadNextLevel();
        menuRef.SetActive(true);  //Loads Main Menu
    }

    public void LoseMainMenu()
    {
        loseLevelUI.SetActive(false);
        levelLoaderRef.GetComponent<LevelLoadScript>().ReloadLevel();
        menuRef.SetActive(true);
    }
    public void NextSceneLoader()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadScene(sceneToContinue + 1);
        Camera.main.fieldOfView = 90;
    }
    
    //Reload Button Functionality
    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Gets the current Scene Index and play it from beginning
        SceneManager.LoadScene(currentSceneIndex);
    }
}