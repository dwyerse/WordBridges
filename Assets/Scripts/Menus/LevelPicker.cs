using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelPicker : MonoBehaviour {
	public GameObject content;
    public GameObject levelButtonPrefab;
	levels l = GameInfo.l;
	int buttonAmount = 20;
	int diff;
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
            GameObject buttonGO = Instantiate(levelButtonPrefab);
			Button buttonBU = buttonGO.GetComponent<Button>();
			buttonBU.onClick.AddListener(() => taskOnClick((i+1)));
            TextMeshProUGUI txt = buttonGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
			txt.text = "LEVEL " + (i +1) ;


			if (PlayerPrefs.HasKey(diff+"-" + (i+1)))
			{
                txt.color = Color.green;
			}
			else
			{
				txt.color = Color.white;
			}
            buttonGO.transform.SetParent(content.transform);

		}        


	}

	void taskOnClick(int i)
	{
		GameInfo.chosenLevel = i;
		SceneManager.LoadScene("WordBridges");
	}

}
