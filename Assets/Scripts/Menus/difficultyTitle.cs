using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyTitle : MonoBehaviour {

	public Text title;

	// Use this for initialization
	void Start () {
		int diff = GameInfo.currentDif;
	   
		switch (diff)
		{
			case 0:
				title.text = "EASY";
				break;
			case 1:
				title.text = "MEDIUM";
				break;
			case 2:
				title.text = "HARD";
				break;
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
