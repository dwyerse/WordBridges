using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsStart : MonoBehaviour {

    public TextMesh t;

    // Use this for initialization
    void Start()
    {
        t.text = "" + PlayerPrefs.GetInt("coins");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
