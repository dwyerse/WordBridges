using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelsButton : MonoBehaviour {
	public void onClick()
	{
		GameInfo.play = 0;
		SceneManager.LoadScene("DifficultyLevels");
	}


}
