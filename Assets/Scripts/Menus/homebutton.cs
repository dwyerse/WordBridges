using UnityEngine;
using UnityEngine.SceneManagement;

public class homebutton : MonoBehaviour
{

    public void OnClick()
    {
        SceneManager.LoadScene("Menu");
    }

}
