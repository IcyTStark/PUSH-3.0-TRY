using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Shop Scrit that takes care of all things happening in shop
[Serializable]
public class ShopItem
{
    public Sprite CharacterImage;
    public GameObject charactersModel;
    public int Price;
    public bool isPurchased = false;
}       //All shop items
//**
[Serializable]
public class ShopData
{
    public List<ShopItem> ShopItemData;
}   //Get an array of shop Items

//Just another extra buttonExtension for Listening to events
public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> onClick)
    {
        button.onClick.AddListener(delegate ()
        {
            onClick(param);
        });
    }
}

public class Shop : MonoBehaviour
{
    ShopData myShopData;
    public List<ShopItem> ShopItemsList;

    [Header("Panel Holders")]
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsHolder;
    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject CoinShopPanel;

    [Space]
    [Header("Item Template & Display")]
    GameObject ItemTemplate;
    GameObject g;
    
    [Space]
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;
    
    //Cached Refernce
    GameObject getGameManager;
    GameManager GameManagerRef;

    public GameObject creditPanelOff;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("ShopData"))
        {
            string jsonString = PlayerPrefs.GetString("ShopData");
            ShopData shopData = JsonUtility.FromJson<ShopData>(jsonString);
            myShopData = shopData;
            ShopItemsList = myShopData.ShopItemData;
        }
        else
        {
            myShopData = new ShopData();
            myShopData.ShopItemData = ShopItemsList;
        }

    }
    //Instantiates shopItems based on values we give in Inspector
    private void Start()
    {
        getGameManager = GameObject.Find("GameManager");            //Finds the GameManager 
        GameManagerRef = getGameManager.GetComponent<GameManager>(); //Store GameManagerScript
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;


   var length = ShopItemsList.Count;//myShopDataList.ShopItemData.Length;
        for (int i = 0; i < length; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].CharacterImage; //myShopDataList.ShopItemData[i].CharacterImage;  //**
            g.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = ShopItemsList[i].Price.ToString(); //myShopDataList.ShopItemData[i].Price.ToString();  //**
            buyBtn = g.transform.GetChild(2).GetComponent<Button>();
            if (ShopItemsList[i].isPurchased)
            {
                DisableBuyButton();
            }
            buyBtn.AddEventListener(i, OnShopItemBtnClicked);
        }
        Destroy(ItemTemplate);
        //LoadMyData(Application.dataPath + "/ShopItems.json");
    }

    //Function to disable buyButton & change the button text to purchased
    public void DisableBuyButton()
    {
        buyBtn.interactable = false;
        buyBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "PURCHASED";
    }

    #region Opening & closing CoinPackShop
    public void OpenShop()
    {
        MainMenu.SetActive(false);
        SettingsHolder.SetActive(false);
        ShopPanel.SetActive(false);
        CoinShopPanel.SetActive(true);
    }

    public void ReturnButton()
    {
        MainMenu.SetActive(true);
        SettingsHolder.SetActive(true);
        ShopPanel.SetActive(true);
        CoinShopPanel.SetActive(false);
    }
    #endregion

    //Once clicked on a BuyButton get the index of what button and do things accordingly 
    void OnShopItemBtnClicked(int itemIndex)
    {
        if (GameManagerRef.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            //purchase Item
            GameManagerRef.UseCoins(ShopItemsList[itemIndex].Price);
            ShopItemsList[itemIndex].isPurchased = true;
            buyBtn = ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            GameManagerRef.character.Add(ShopItemsList[itemIndex].charactersModel);
            myShopData.ShopItemData[itemIndex].isPurchased = true;
            string jsonString = JsonUtility.ToJson(myShopData);
            PlayerPrefs.SetString("ShopData", jsonString);
            DisableBuyButton();

            //**
            #region "Save the purchased character"

            GameManagerRef.mPurchasedCharaters = GameManagerRef.mPurchasedCharaters + GameManagerRef.mCharacterDemiliter + ShopItemsList[itemIndex].charactersModel.name;
            PlayerPrefs.SetString("SavedCharacters", GameManagerRef.mPurchasedCharaters);

            ////PlayerPrefs.SetInt("SaveCharacterPurchaseData", boolToInt(ShopItemsList[itemIndex].isPurchased));

            #endregion
        }
        else
        {
            Debug.Log("You dont have sufficient amount");
        }
    }

    public void thousandCoins()
    {
        //Implement Getting Coins
    }
    public void twoThousandCoins()
    {
        //Implement Two Thousand Coins
    }
    public void threeThousandCoins()
    {
        //Implement Three thousand Coins
    }
    public void fourThousandCoins()
    {
        //Implement four thousand COins
    }

    public void creditsPageReturn()
    {
        creditPanelOff.SetActive(false);
    }
}