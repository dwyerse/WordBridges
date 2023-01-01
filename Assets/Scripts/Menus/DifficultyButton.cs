using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DifficultyButton : MonoBehaviour
{
    public TextMeshProUGUI tm;
    public int difficulty;

    public void Start()
    {
        int compl = 0;
        for (int i = 0; i < 20; i++)
        {
            if (PlayerPrefs.HasKey(difficulty + "-" + (i + 1)))
            {
                compl++;
            }
        }
        tm.text = tm.text + " " + compl + "/" + 20;
    }

    public void OnClick()
    {
        GameInfo.currentDiff = difficulty;
        SceneManager.LoadScene("Levels");
    }

}