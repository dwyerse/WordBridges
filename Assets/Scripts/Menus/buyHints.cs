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
        
        Purchaser p = new Purchaser();
        switch (value)
        {
            case 100:
                p.buyCoins100();
                break;
            case 200:
                p.buyCoins200();
                break;
            case 1000:
                p.buyCoins1000();
                break;
            case 10000:
                p.buyCoins10000();
                break;
            case 0:
                p.buyNoAds();
                break;
        }

        int coins = PlayerPrefs.GetInt("coins");
        coinTm.text = "" + (coins + value);

    }

}
