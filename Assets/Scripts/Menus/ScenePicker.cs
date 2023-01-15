using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ScenePicker : MonoBehaviour
{

    public string scene;
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(scene));
    }
}
