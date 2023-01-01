using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPicker : MonoBehaviour
{
    public GameObject content;
    public GameObject levelButtonPrefab;
    readonly int buttonAmount = 20;
    int diff;

    public void Start()
    {
        diff = GameInfo.currentDiff;
        CreateButtons();
    }

    void CreateButtons()
    {
        for (int i = 0; i < buttonAmount; i++)
        {
            GameObject buttonGO = Instantiate(levelButtonPrefab);
            Button buttonBU = buttonGO.GetComponent<Button>();
            buttonBU.name = "" + (i + 1);
            buttonBU.onClick.AddListener(() => TaskOnClick(buttonBU.name));
            TextMeshProUGUI txt = buttonGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            txt.text = "LEVEL " + (i + 1);

            if (PlayerPrefs.HasKey(diff + "-" + (i + 1)))
            {
                txt.color = Color.green;
            }
            else
            {
                txt.color = Color.white;
            }
            buttonGO.transform.SetParent(content.transform, false);

        }


    }

    void TaskOnClick(String i)
    {
        GameInfo.chosenLevel = Int32.Parse(i);
        SceneManager.LoadScene("WordBridges");
    }

}
