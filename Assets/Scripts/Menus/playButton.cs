using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnClick()
    {
        GameInfo.play = 1;
        SceneManager.LoadScene("WordBridges");
    }
}
