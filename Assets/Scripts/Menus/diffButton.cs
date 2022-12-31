using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class diffButton : MonoBehaviour
{
    public TextMeshProUGUI tm;
    public int difficulty;

    void Start()
    {
        levels l = GameInfo.l;
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

    public void onClick()
    {
        GameInfo.currentDiff = difficulty;
        SceneManager.LoadScene("Levels");
    }

}