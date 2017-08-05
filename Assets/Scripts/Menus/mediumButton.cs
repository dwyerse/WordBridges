using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mediumButton : MonoBehaviour {
	public TextMesh tm;
	// Use this for initialization
	void Start () {
		levels l = GameInfo.l;
        int compl = 0;
		for (int i = 0; i < l.medium; i++)
		{
			if (PlayerPrefs.HasKey(1 + "-" + (i + 1)))
			{
				compl++;
			}
		}
		tm.text = "" + compl + "/" + l.medium;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
        GameInfo.currentDif = 1;

        StartCoroutine(change());
    }

    IEnumerator change()
    {
        float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().beginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Levels");
    }
}
