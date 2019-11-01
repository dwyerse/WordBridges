﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelPicker : MonoBehaviour {
	public GameObject content;
	levels l = GameInfo.l;
	int buttonAmount = 20;
	int diff;
	float buttonHeight = 200f;
	public ScrollRect sr;
	// Use this for initialization
	void Start () {

		
		diff = GameInfo.currentDif;	      

		createButtons();

	}
	
	void createButtons()
	{
		//Box part of buttons
		for (int i = 0; i < buttonAmount; i++)
		{
			GameObject buttonGO = new GameObject();
			buttonGO.name = "" + (i +1);
			RectTransform buttonRT = buttonGO.AddComponent<RectTransform>();
			buttonRT.sizeDelta = new Vector2(700.0f, buttonHeight);
			Button buttonBU = buttonGO.AddComponent<Button>();
			buttonBU.onClick.AddListener(() => taskOnClick((int)(i+1),buttonBU.name));
			GameObject tOb = new GameObject();
			tOb.name = "text";
			tOb.transform.SetParent(buttonGO.transform);
			Text txt = tOb.AddComponent<Text>();
			Image buttonIM = buttonGO.AddComponent<Image>();
			buttonIM.sprite = Resources.Load("UISprite", typeof(Sprite)) as Sprite;
			buttonGO.transform.SetParent(content.transform);
			txt.text = "LEVEL " + (i +1) ;


			if (PlayerPrefs.HasKey(diff+"-" + (i+1)))
			{
				txt.color = new Color32(0x07, 0x8E, 0x01, 0xFF);
			}
			else
			{
				txt.color = Color.grey;
			}
			
			txt.font = Resources.Load<Font>("Fonts/Composition");
			txt.fontSize = 65;
			txt.GetComponent<RectTransform>().sizeDelta = new Vector2(700.0f, 200.0f);
			txt.alignment = TextAnchor.MiddleCenter;
			buttonGO.GetComponent<RectTransform>().localPosition = new Vector3(0, -200 + (i * -300), 0);

		}        


	}

	void taskOnClick(int i,string button)
	{
		GameInfo.chosenLevel = Convert.ToInt32(button);
		SceneManager.LoadScene("WordBridges");
	}

}
