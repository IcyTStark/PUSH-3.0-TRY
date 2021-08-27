using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//Takes care of all coin count & everything
public class GameManager : MonoBehaviour
{
    //config params
    public static GameManager Instance; //Implementing Singleton and creating an Instance

    [Header("Coin Count & Loading: ")]
    public int coin = 0;
    int savedCoin;

    //Get the LevelManager of that specific scene
    [HideInInspector] public GameObject shopRef;
    [HideInInspector] public Shop storeShopScript;
    
    //Manage CharacterCount and update to LevelManager
    public List<GameObject> character = new List<GameObject>();

    // StringDelimiterMethod for Saving & Loading characters
    [HideInInspector] public string mPurchasedCharaters = string.Empty;
    [HideInInspector] public string[] mPurchasesCharacterList;
    [HideInInspector] public char mCharacterDemiliter = '/';

    void Awake()
    {
        //Loads the coin save Data
        LoadCoinSaveData();
        //Makes sure only one GameManager is there at a time
        #region "Singleton Code"
        //Checks to see if there is another gameManager instance and deletes that
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this); //Singleton
            return;
        }
        Destroy(this.gameObject);
        #endregion
    }

    private void Start()
    {
        GameObject menuRef = GameObject.Find("Menu");
        // Populate purchased characters
        PopulateCharacters();
    }
    #region "Populate SavedCharacters"
    public void PopulateCharacters()
    {
        mPurchasedCharaters = PlayerPrefs.GetString("SavedCharacters");
        
        if(mPurchasedCharaters == string.Empty)
        {
            mPurchasedCharaters = "Man";
            PlayerPrefs.SetString("SavedCharacters", mPurchasedCharaters);
        }
        mPurchasesCharacterList = mPurchasedCharaters.Split(mCharacterDemiliter);

        foreach (var sub in mPurchasesCharacterList)
        {
            GameObject loadedCharacter =  Resources.Load(sub) as GameObject;
            character.Add(loadedCharacter);
        }
    }

    #endregion

    private void LoadCoinSaveData()
    {
        savedCoin = PlayerPrefs.GetInt("SavedCoinValue");
        coin = savedCoin;
    }   //Loads the saved Coin

    //Reduce the coin value depending upon the amount
    public void UseCoins(int amount)
    {
        coin -= amount;
    }  
    
    //Use coins if enough coins are there? Check if enough coins are there for the purchase 
    public bool HasEnoughCoins(int amount)
    {
        return (coin >= amount);
    }
}