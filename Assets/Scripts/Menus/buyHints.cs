using CompleteProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyHints : MonoBehaviour {

    public int cost;
    public int value;
    public TextMesh coinTm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        int coins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", coins + value);
        coinTm.text = "" + (coins + value);
        Purchaser p = new Purchaser();
        p.buyCoins100();
    }

}
