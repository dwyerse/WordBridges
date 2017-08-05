using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelsButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touches.Length > 0) //if any finger are on the screen 
		{
			Touch touch = Input.touches[0];
			Rect rect = new Rect(0, 0, 150, 150); //rect of your Arrow for the next level
			if (rect.Contains(touch.position))
			{
				//Do actions
			}
		}
	}

	private void OnMouseDown()
	{
		GameInfo.play = 0;
       
        StartCoroutine(change());
    }

    IEnumerator change()
    {
        float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().beginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("DifficultyLevels");
    }

}
