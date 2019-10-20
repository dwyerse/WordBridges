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
        go.transform.localScale = new Vector2(0, 0);
        LeanTween.scale(go, new Vector2(0.3f, 0.3f), 0.2f).setOnComplete(DestroyMe);
        LeanTween.alpha(go, 0, 0.2f);
    }
       
    void DestroyMe()
    {
        Destroy(go);
    }

}
