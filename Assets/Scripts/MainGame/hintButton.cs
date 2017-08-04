using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintButton : MonoBehaviour {

    int count = 0;
    public TextMesh coinsText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GameObject[] containers = GameObject.FindGameObjectsWithTag("container");
         if (count < containers.Length)
        {
            GameObject letter = new GameObject();
            Vector3 vec = containers[count].transform.position;           
            letter.GetComponent<Transform>().position = vec;
            letter.AddComponent<TextMesh>();
            letter.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
            letter.GetComponent<TextMesh>().characterSize = 0.06f;
            letter.GetComponent<TextMesh>().fontSize = 60;
            letter.transform.SetParent(containers[count].transform);
            letter.GetComponent<TextMesh>().text = containers[count].GetComponent<containerBehaviour>().c;
            letter.GetComponent<TextMesh>().color = new Color32(0x44, 0xDD, 0x44, 0xAA);
            count++;
            int c = PlayerPrefs.GetInt("coins");
            PlayerPrefs.SetInt("coins", c - 10);
            coinsText.text = "COINS:" + PlayerPrefs.GetInt("coins");
        }        
    }
}
