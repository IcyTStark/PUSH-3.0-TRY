using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Takes Care of Level Completion/Win Condition To that specific level & Coins
public class LevelManager : MonoBehaviour
{
    //Configuration Variables
    [Space]
    public GameObject[] destinations;   //Gets the destination count for each level locally

    [Space]
    [Header("Coin Display & Count")]
    [SerializeField] TextMeshProUGUI coinText;      //Text to display Coin
    int coin;
    int twoXCoin;
    int currentCoinValue = 0;

    [Space]
    [Header("Next Level and Load Timing")]
    GameObject nextLevelUI;
    public float waitTimeBetweenLevels;

    public GameObject[] giftsInScene;
    public List<Animator> giftAnimator = new List<Animator>();

    GameObject XTwoCoinsText;

    //Cached Reference
    [Space]
    [SerializeField] GameObject LevelManagerRef;
    GameManager gameManager;
    
    //State Variables
    bool isDone;
    bool advertismentWatched = false;

    void Start()
    {
        advertismentWatched = false;
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
        {
            destinations = GameObject.FindGameObjectsWithTag("Destination"); // To calculate Target points in scene
            giftsInScene = GameObject.FindGameObjectsWithTag("Gift"); //To calculate coin count

            foreach (GameObject gift in giftsInScene)
            {
                var storegiftAnimators = gift.GetComponent<Animator>();
                giftAnimator.Add(storegiftAnimators);
            }

            //Gets the NextLevelUI Panel
            nextLevelUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;

            //Gets the CoinText from next Level Panel
            coinText = nextLevelUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            XTwoCoinsText = nextLevelUI.transform.GetChild(5).transform.GetChild(1).gameObject;

            //isDone is false as the game is not complete yet becomes true when win condition is successfull
            isDone = false;

            //Getting cache Refernce of GameManager
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            //Getting a reference of level specific Level Loader
            LevelManagerRef = this.gameObject;
        }
    }
    
    void Update()
    {
        if (!isDone)
        {
            //Win Condition
            foreach (GameObject destination in destinations)         
            {
                if (!destinations.Any(go => go.GetComponent<DestinationReached>().destinationReached == false))
                {
                    Invoke("MakeNextLevelUIActive", 3f);   //Invokes NextLevelUI 
                    SaveScene();        //Saves the scene
                    isDone = true;
                }
            }  
            if (isDone)         //Takes care of all the coin updating 
            {
                currentCoinValue = 10 * giftsInScene.Length;    //Each gift 10 coins
                coin = coin + currentCoinValue;
                //Keep updating coin
                displayCoinMultiplierText();
                AssignAndSaveCoins();
            }
        }
    }


    //On Level Complete Saves the sceneindex of the completed level
    public void SaveScene()
    {
        PlayerPrefs.SetInt("SavedScene", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    //Makes the next level UI active
    void MakeNextLevelUIActive()
    {
        nextLevelUI.SetActive(true);
    }

    void displayCoinMultiplierText()
    {
        XTwoCoinsText.GetComponent<TextMeshProUGUI>().text = (currentCoinValue * 2).ToString();
    }

    public void CoinMultiplier()
    {
        currentCoinValue += currentCoinValue;
        AssignAndSaveCoins();
        //Play the Advertisement First

            //Code

        //&
        //Add the coins in Game
        //coin *= 2;
        //AssignAndSaveCoins();
    }

    private void AssignAndSaveCoins()
    {
        gameManager.coin += this.coin;
        coinText.text = currentCoinValue.ToString();
        PlayerPrefs.SetInt("SavedCoinValue", gameManager.coin);
        //displayCoinMultiplierText();
    }
    void InvoIsDone()
    {
        isDone = true;
    }
}