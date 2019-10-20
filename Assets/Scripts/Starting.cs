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
		TextAsset txt = (TextAsset)Resources.Load("unixdict", typeof(TextAsset));
		string[] words = txt.text.Split('\n');
        print("Loading words...");
        foreach (string word in words)
        {
            GameInfo.wordSet.Add(word.Trim());
        }
        
	}
}
