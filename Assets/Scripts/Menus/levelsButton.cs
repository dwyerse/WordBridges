using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButton : MonoBehaviour
{
    public void OnClick()
    {
        GameInfo.play = 0;
        SceneManager.LoadScene("DifficultyLevels");
    }


}
