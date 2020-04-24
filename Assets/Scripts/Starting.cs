using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Starting : MonoBehaviour
{

    // Use this for initialization
    void Start()
	{
		if (GameInfo.wordSet == null)
		{
			GameInfo.wordSet = new HashSet<string>();
			TextAsset txt = (TextAsset)Resources.Load("unixdict", typeof(TextAsset));
			string[] words = txt.text.Split('\n');
			print("Loading words...");
			foreach (string word in words)
			{
				GameInfo.wordSet.Add(word.Trim());
			}
		}

	}
}