using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
	[Header("space between menu items")]
	[SerializeField] Vector2 spacing;

	[Space]
	[Header("Main button rotation")]
	[SerializeField] float rotationDuration;
	[SerializeField] Ease rotationEase;

	[Space]
	[Header("Animation")]
	[SerializeField] float expandDuration;
	[SerializeField] float collapseDuration;
	[SerializeField] Ease expandEase;
	[SerializeField] Ease collapseEase;

	[Space]
	[Header("Fading")]
	[SerializeField] float expandFadeDuration;
	[SerializeField] float collapseFadeDuration;

	Button mainButton;
	SettingsMenuItem[] menuItems;

	//is menu opened or not
	bool isExpanded = false;
	bool isMuted;
	public Image img;
	public Sprite musicON, musicOFF;

	public GameObject creditPanel;

	Vector2 mainButtonPosition;
	int itemsCount;

	void Start()
	{
		img.sprite = musicON;
		creditPanel.SetActive(false);
		//add all the items to the menuItems array
		itemsCount = transform.childCount - 1;
		menuItems = new SettingsMenuItem[itemsCount];
		for (int i = 0; i < itemsCount; i++)
		{
			// +1 to ignore the main button
			menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
		}

		mainButton = transform.GetChild(0).GetComponent<Button>();
		mainButton.onClick.AddListener(ToggleMenu);
		//SetAsLastSibling () to make sure that the main button will be always at the top layer
		mainButton.transform.SetAsLastSibling();

		mainButtonPosition = mainButton.transform.position;

		//set all menu items position to mainButtonPosition
		ResetPositions();

		isMuted = PlayerPrefs.GetInt("MUTED") == 1;
		AudioListener.pause = isMuted;
	}

	void ResetPositions()
	{
		for (int i = 0; i < itemsCount; i++)
		{
			menuItems[i].trans.position = mainButtonPosition;
		}
	}

	void ToggleMenu()
	{
		isExpanded = !isExpanded;

		if (isExpanded)
		{
			//menu opened
			for (int i = 0; i < itemsCount; i++)
			{
				menuItems[i].trans.DOMove(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
				//Fade to alpha=1 starting from alpha=0 immediately
				//menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
			}
		}
		else
		{
			//menu closed
			for (int i = 0; i < itemsCount; i++)
			{
				menuItems[i].trans.DOMove(mainButtonPosition, collapseDuration).SetEase(collapseEase);
				//Fade to alpha=0
				//menuItems[i].img.DOFade(0f, collapseFadeDuration);
			}
		}

		//rotate main button arround Z axis by 180 degree starting from 0
		mainButton.transform
			.DORotate(Vector3.forward * 180f, rotationDuration)
			.From(Vector3.zero)
			.SetEase(rotationEase);
	}

	public void OnItemClick(int index)
	{
		//here you can add you logic 
		switch (index)
		{
			case 0:
				//second button
				MutePressed();
				ChangeSprites();
				break;
			case 1:
				//third button
				Debug.Log("Google");
				break;
			case 2:
				//fourth button
				Debug.Log("Facebook");
				break;
			case 3:
				//fifth Button
				ToggleCreditScreen();
				break;

		}
	}

    private void MutePressed()
    {
		isMuted = !isMuted;
		AudioListener.pause = isMuted;
		PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
	void ChangeSprites()
    {
		if(img.sprite == musicON)
        {
			img.sprite = musicOFF;
        }
		else if(img.sprite == musicOFF)
        {
			img.sprite = musicON;
        }
	}

	void ToggleCreditScreen()
    {
		if(creditPanel.activeInHierarchy == true)
        {
			creditPanel.SetActive(false);
        }
		else
        {
			creditPanel.SetActive(true);
        }
    }

	void OnDestroy()
	{
		//remove click listener to avoid memory leaks
		mainButton.onClick.RemoveListener(ToggleMenu);
	}
}
