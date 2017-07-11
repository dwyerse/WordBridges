using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {
   
    // Use this for initialization
    void Start () {
        GameObject con = new GameObject();
        con.layer = 2;
        con.AddComponent<SpriteRenderer>();
        con.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/letterbox");
        con.GetComponent<SpriteRenderer>().color = Color.grey;
        con.GetComponent<SpriteRenderer>().sortingOrder = -1;
        con.AddComponent<BoxCollider2D>();
        con.AddComponent<containerBehaviour>();
        con.AddComponent<Rigidbody2D>();
        var rb = con.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;      
        con.tag = "container";
        
    }
	
	// Update is called once per frame
	void Update () {
        if (complete())
        {
            transform.GetComponent<TextMesh>().text = "Win";
        }
	}

    bool complete()
    {
        GameObject[] containers = GameObject.FindGameObjectsWithTag("container");

        for (int i = 0; i < containers.Length; i++)
        {
            containerBehaviour con = containers[i].transform.GetComponent<containerBehaviour>();
            if (!con.isCorrect())
            {
                return false;
            }
        }
        return true;
    }

}
