using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    int phase = 1;
    GameObject[] letters;
    public GameObject arrow;
    public GameObject arrowR;
    public GameObject arrowD;
    public Text advice;

    public GameObject overlay;
    // Use this for initialization
    void Start () {     

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        Debug.Log("Tutorial Active");
        letters = GameObject.FindGameObjectsWithTag("letterbox");
        foreach (GameObject go in letters)
        {
            go.GetComponent<SpriteRenderer>().sortingLayerName = "tutorial";
            go.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }

    }

    public void nextPhase(int dir)
    {
        
        phase+=dir;

        switch (phase)
        {
            case 1:
                foreach (GameObject go in letters)
                {
                    go.GetComponent<SpriteRenderer>().sortingLayerName = "tutorial";
                    go.GetComponent<SpriteRenderer>().sortingOrder = 0;
                }
            break;
            case 2:                
                advice.text = "CREATE TWO WORDS \n THAT FIT THE BLOCKS";
                arrowD.SetActive(true);
                arrowR.SetActive(true);
                arrow.SetActive(false);                
                break;
            case 3:
                foreach (GameObject go in letters)
                {
                    go.GetComponent<SpriteRenderer>().sortingLayerName = "boxes";
                    go.GetComponent<SpriteRenderer>().sortingOrder = 0;
                }
                advice.text = "";
                
                arrowD.SetActive(false);
                arrowR.SetActive(false);
                overlay.SetActive(false);
            break;
        }

    }

}
