using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickControl : MonoBehaviour {
    public Vector3 og;
    public Vector3 hole;
    public int insert = 0;   
    GameObject[] containers;
    // Use this for initialization
    void Start () {
        og = new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
  
    private void OnMouseDrag()
    {
        Vector3 poscam = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Camera c = Camera.main;
        Vector3 pos = c.ScreenToWorldPoint(poscam);        
        pos.z = 0;
        transform.position = pos;
        emptyContainer(transform.GetInstanceID());
    }

    void emptyContainer(int id)
    {
        containers = GameObject.FindGameObjectsWithTag("container");
        for (int i=0;i<containers.Length;i++)
        {
            containerBehaviour con = containers[i].transform.GetComponent<containerBehaviour>();            
            if (con.occupant !=null && con.occupant.GetInstanceID() == id)
            {
                con.occupant = null;
                con.full = false;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D coll)
    {       

        if (coll.tag == "container")
        {
            containerBehaviour tmp = coll.gameObject.GetComponent<containerBehaviour>();
            if (!tmp.full)
            {

                Vector3 a = tmp.transform.position;
                Vector3 b = transform.position;
                float dist = Vector3.Distance(a, b);               
                if (dist < maxDistance || coll.gameObject.GetInstanceID() == insert)
                {
                    maxDistance = dist;
                    cB = tmp;
                    insert = coll.gameObject.GetInstanceID();
                    hole = new Vector3(coll.transform.position.x, coll.transform.position.y, coll.transform.position.z);
                }
            }
        }
    }

    containerBehaviour cB;
    float maxDistance = 100000;
    public void OnTriggerEnter2D(Collider2D coll)
    {
      
        if (coll.tag == "container") {
         
            containerBehaviour tmp = coll.gameObject.GetComponent<containerBehaviour>();
            if (!tmp.full){
                Vector3 a = tmp.transform.position;
                Vector3 b = transform.position;
                float dist = Vector3.Distance(a, b);
                if (dist < maxDistance || coll.gameObject.GetInstanceID() == insert)
                {
                    maxDistance = dist;
                    cB = tmp;
                    insert = coll.gameObject.GetInstanceID();
                    hole = new Vector3(coll.transform.position.x, coll.transform.position.y, coll.transform.position.z);
                }                
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {           
        if (coll.tag == "container")
        {
            containerBehaviour tmp = coll.gameObject.GetComponent<containerBehaviour>();
            if (tmp.full == false)
            { 
                if (insert == coll.gameObject.GetInstanceID())
                {
                    insert = 0;
                }
            }
        }
    }

    private void OnMouseUp()
    {
        if (Math.Abs(insert)>0)
        {
            transform.position = hole;
            cB.full = true;
            cB.occupant = transform;           
        }
        else
        {
            transform.position = og;
            if (cB != null)
            {
                int s = transform.GetInstanceID();
                int occ = -1;
                if (cB.occupant != null)
                {
                    occ = cB.occupant.GetInstanceID();
                }
                if (s == occ)
                {
                    cB.full = false;
                    cB.occupant = null;
                }                         
            }
        }        
    }
}
