using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextButton : MonoBehaviour {
    public Button b;
    // Use this for initialization
    void Start () {
        b.onClick.AddListener(() => nextClick());
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    private void nextClick()
    {
        GameInfo.chosenLevel++;
        int diff =0;
        switch (GameInfo.currentDif)
        {
            case 0:
                diff = GameInfo.l.easy;
                break;
            case 1:
                diff = GameInfo.l.medium;
                break;
            case 2:
                diff = GameInfo.l.hard;
                break;
        }
        if (GameInfo.chosenLevel > diff)
        {
            GameInfo.chosenLevel = 1;
            SceneManager.LoadScene("DifficultyLevels");
        }
        else
        {
            GameInfo.play = 0;
            SceneManager.LoadScene("WordBridges");
        }
    }
}
