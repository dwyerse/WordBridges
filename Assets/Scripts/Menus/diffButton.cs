using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class diffButton : MonoBehaviour
{
    public TextMeshProUGUI tm;
    public int difficulty;
    // Use this for initialization
    void Start()
    {
        levels l = GameInfo.l;
        int compl = 0;
        for (int i =0; i < 20; i++)
        {
            if (PlayerPrefs.HasKey(difficulty+"-"+(i+1)))
            {
                compl++;
            }
        }
        tm.text = tm.text + " " + compl + "/" + 20; 
    }

    public void onClick()
    {
        GameInfo.currentDiff = difficulty;
        SceneManager.LoadScene("Levels");
    }    

}