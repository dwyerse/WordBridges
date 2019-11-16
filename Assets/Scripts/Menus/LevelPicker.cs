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

		
		diff = GameInfo.currentDiff;	      

		createButtons();

	}
	
	void createButtons()
	{
		//Box part of buttons
		for (int i = 0; i < buttonAmount; i++)
		{
            GameObject buttonGO = Instantiate(levelButtonPrefab);
			Button buttonBU = buttonGO.GetComponent<Button>();
			buttonBU.name = "" + (i+1);
			buttonBU.onClick.AddListener(() => taskOnClick(buttonBU.name));
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

	void taskOnClick(String i)
	{
		print(i);
		GameInfo.chosenLevel = Int32.Parse(i);
		SceneManager.LoadScene("WordBridges");
	}

}
