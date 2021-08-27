using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoin : MonoBehaviour
{
    //Config params
    GameObject MainMenuCanvas;
    GameObject GameManagerRef;
    void Start()
    {
        MainMenuCanvas = GameObject.Find("MainMenuCanvas");
        GameManagerRef = GameObject.Find("GameManager");
    }

    void Update()
    {
        MainMenuCanvas.transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = GameManagerRef.GetComponent<GameManager>().coin.ToString();
    }
}
