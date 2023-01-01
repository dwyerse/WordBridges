using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public Button b;
    // Use this for initialization
    public void Start()
    {
        b.onClick.AddListener(() => NextClick());
    }

    private void NextClick()
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
