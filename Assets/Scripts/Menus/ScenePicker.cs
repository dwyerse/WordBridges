using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePicker : MonoBehaviour
{
    public string scene;
    public void OnClick()
    {
        SceneManager.LoadScene(scene);
    }
}
