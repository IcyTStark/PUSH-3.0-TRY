using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playButton : MonoBehaviour
{
    public Button button;
    public LevelLoadScript mainmenu;

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
    }
    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0)
        {
            mainmenu = GameObject.Find("LevelLoader").GetComponent<LevelLoadScript>();
            button.onClick.AddListener(mainmenu.play);
        }
    }
}
