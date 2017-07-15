using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelPicker : MonoBehaviour {
    public GameObject content;
    int buttonAmount = 5;
	// Use this for initialization
	void Start () {

        createButtons();
        
    }
	
    void createButtons()
    {
        //Box part of buttons
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject buttonGO = new GameObject();
            buttonGO.name = "Button";
            RectTransform buttonRT = buttonGO.AddComponent<RectTransform>();
            buttonRT.sizeDelta = new Vector2(700.0f, 200.0f);
            Button buttonBU = buttonGO.AddComponent<Button>();
            GameObject tOb = new GameObject();
            tOb.name = "text";
            tOb.transform.SetParent(buttonGO.transform);
            Text txt = tOb.AddComponent<Text>();
            buttonBU.onClick.AddListener(() => { Debug.Log("button clicked"); });
            Image buttonIM = buttonGO.AddComponent<Image>();
            buttonIM.sprite = Resources.Load("UISprite", typeof(Sprite)) as Sprite;
            buttonGO.transform.SetParent(content.transform);
            txt.text = "LEVEL " + (i +1) ;
            txt.color = Color.grey;
            txt.font = Resources.Load<Font>("Fonts/Composition");
            txt.fontSize = 65;
            txt.GetComponent<RectTransform>().sizeDelta = new Vector2(700.0f, 200.0f);
            txt.alignment = TextAnchor.MiddleCenter;
            buttonGO.GetComponent<RectTransform>().localPosition = new Vector3(0, -200 + (i * -300), 0);

        }        


    }


	// Update is called once per frame
	void Update () {
		
	}
}
