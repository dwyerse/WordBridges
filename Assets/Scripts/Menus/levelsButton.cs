using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelsButton : MonoBehaviour {


	private void OnMouseDown()
	{
		GameInfo.play = 0;
        SceneManager.LoadScene("DifficultyLevels");
    }


}
