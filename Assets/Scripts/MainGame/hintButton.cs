using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintButton : MonoBehaviour {

    int count = 0;
    public TextMesh coinsText;
    public GameObject cost;
    public GameObject shop;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GameObject[] containers = GameObject.FindGameObjectsWithTag("container");
        GameObject[] hints = GameObject.FindGameObjectsWithTag("hint");
        if (count < containers.Length)
        {
            int c = PlayerPrefs.GetInt("coins");
            if (c < 0)
            {
                PlayerPrefs.SetInt("coins", 0);
            }
            if (c < 10)
            {
                //Open Shop
                shop.SetActive(true);
            }
            else
            {
                GameObject letter = hints[count];
                Vector3 vec = containers[count].transform.position;
                vec = new Vector3(vec.x,vec.y-0.03f,vec.z);
                letter.GetComponent<Transform>().position = vec;
                letter.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;
                letter.GetComponent<TextMesh>().characterSize = 0.06f;
                letter.GetComponent<TextMesh>().fontSize = 60;
                letter.transform.SetParent(containers[count].transform);
                letter.GetComponent<TextMesh>().text = containers[count].GetComponent<containerBehaviour>().c;
                letter.GetComponent<TextMesh>().color = new Color32(0x44, 0xDD, 0x44, 0xAA);                
                count++; 
                PlayerPrefs.SetInt("coins", c - 10);
                StartCoroutine(showCost());
            }            
            coinsText.text = "" + PlayerPrefs.GetInt("coins");
        }        
    }


    IEnumerator showCost()
    {
        cost.SetActive(true);
        TextMesh tm = cost.GetComponent<TextMesh>();
     
        for (float i = 0; i < 1; i += 0.01f)
        {
            yield return new WaitForSeconds(0.001f);
            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, 1-i);
        }
    }
}
