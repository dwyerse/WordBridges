using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour {

    public float gf = 0.015f;
    public float incr = 0.001f;
    private GameObject go;
    public void produceSlotEffect(Transform t)
    {
        go = new GameObject();
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/box");
        go.transform.position = t.position;
        go.name = "slotEffect";
        go.transform.localScale = new Vector2(0.1f,0.1f);
        StartCoroutine(slot());
    }
       
    IEnumerator slot()
    {
        float oga = go.GetComponent<SpriteRenderer>().color.a;
        for (float i=0;i<10;i++)
        {
            if (go != null)
            {
                go.transform.localScale = new Vector2(go.transform.localScale.x + 0.005f, go.transform.localScale.y + 0.005f);
                Color c = go.GetComponent<SpriteRenderer>().color;
                go.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, c.a - 0.1f);
            }
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(go);      
        
    }

}
