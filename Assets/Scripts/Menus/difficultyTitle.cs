﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class difficultyTitle : MonoBehaviour {

	TextMeshProUGUI title;

	// Use this for initialization
	void Start () {
		int diff = GameInfo.currentDiff;
		title = GetComponent<TextMeshProUGUI>();
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
}
