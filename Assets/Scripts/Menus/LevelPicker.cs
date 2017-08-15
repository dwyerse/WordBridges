using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelPicker : MonoBehaviour {
	public GameObject content;
	levels l = GameInfo.l;
	int buttonAmount = 0;
	int diff;
    float buttonHeight = 200f;
    public ScrollRect sr;
	// Use this for initialization
	void Start () {

		
		diff = GameInfo.currentDif;
		switch (diff)
		{
			case 0:
				buttonAmount = l.easy;
				break;
			case 1:
				buttonAmount = l.medium;
				break;
			case 2:
				buttonAmount = l.hard;
				break;
		}        

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


	// Update is called once per frame
	void Update () {

        RectTransform rt = content.GetComponent<RectTransform>();
        float ba = (float)buttonAmount;
        float y = rt.position.y;
        //Debug.Log("y: " + (y -1800) + " ba:" + ba + " bH:" + buttonHeight);
        if (ba * buttonHeight > 6 * buttonHeight)
        {
            if (y > 1000 + ba * buttonHeight)
            {
                rt.position = new Vector3(rt.position.x, 1000 + ba * buttonHeight, rt.position.z);
            }
            else if (y < 1800)
            {
                rt.position = new Vector3(rt.position.x, 1800, rt.position.z);
            }
        }
        else
        {
            sr.vertical = false;
        }

    }

	void taskOnClick(int i,string button)
	{
		GameInfo.chosenLevel = Convert.ToInt32(button);
		SceneManager.LoadScene("WordBridges");
	}

}
