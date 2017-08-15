using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starting : MonoBehaviour {

    public TextMesh t;

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("tutorial"))
        {
            SceneManager.LoadScene("WordBridges");
        }
        t.text = ""+ PlayerPrefs.GetInt("coins");
		TextAsset txt = (TextAsset)Resources.Load("unixdict", typeof(TextAsset));
		GameInfo.l.file = txt.text.Split('\n');

        if (!PlayerPrefs.HasKey("coins"))
        {
            PlayerPrefs.SetInt("coins", 10);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
