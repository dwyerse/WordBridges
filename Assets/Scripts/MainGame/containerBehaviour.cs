using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containerBehaviour : MonoBehaviour {

    public string c;
    public bool full = false;
    public Transform occupant;
    public int i;
    public int j;
	// Use this for initialization
	void Start () {
        occupant = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isCorrect()
    {
        if (occupant != null)
        {
            Transform t = occupant.GetChild(0);
            string a = t.GetComponent<TextMesh>().text;
            if (a.Equals(c))
            {
                return true;
            }
        }
        return false;
    }

}
