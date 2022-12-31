using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextButton : MonoBehaviour
{
    public Button b;
    // Use this for initialization
    void Start()
    {
        b.onClick.AddListener(() => nextClick());
    }

    private void nextClick()
    {
        GameInfo.chosenLevel++;
        int diff = 20;

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
