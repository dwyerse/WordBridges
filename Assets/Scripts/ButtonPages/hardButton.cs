﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hardButton : MonoBehaviour {
    public TextMesh tm;
	// Use this for initialization
	void Start () {
        levels l = new levels();
        int compl = 0;
        for (int i = 0; i < l.hard; i++)
        {
            if (PlayerPrefs.HasKey(2 + "-" + (i + 1)))
            {
                compl++;
            }
        }
        tm.text = "" + compl + "/" + l.hard;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		GameInfo.currentDif = 2;
		SceneManager.LoadScene("Levels");
	}
}
