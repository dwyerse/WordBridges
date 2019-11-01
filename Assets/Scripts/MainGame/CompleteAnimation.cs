using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class CompleteAnimation : MonoBehaviour {
    public static bool c = false;
    GameObject[] letters;
    public GameObject victoryText;
    public GameObject overlay;
    public GameObject next;
    public Transform extra;
    Transform last;
    public float speed = 0.04f;
    public float colorSpeed = 0.04f;
    int phase;
    int colorPhase;
    public Manager manager;


    // Use this for initialization
    void Start () {
        phase = 0;
        colorPhase = 0;
        c = false;
    }

    // Update is called once per frame

    public void startAnimation()
    {
        print("Start Animation");
        for (int i = 0; i < manager.containers.Count; i++)
        {   
            LeanTween.scale(manager.containers[i], new Vector2(1.2f, 1.2f), 1.2f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(AnimationFinished).setOnCompleteParam(i);
        }
    }


    void AnimationFinished(object onCompleteParams)
    {
        int i = (int)onCompleteParams;
        LeanTween.scale(manager.containers[i], new Vector2(0f, 0f), 0.5f).setEase(LeanTweenType.easeInOutQuad);
    }

    void phase2()
    {
        for (int i = 0; i < manager.containers.Count; i++)
        {
            LeanTween.move(manager.containers[i], new Vector2(0.5f, 0.5f), 0.5f);
        }
    }
 

    public void showCompletePanel()
    {        
            victoryText.SetActive(true);
            next.SetActive(true);
            overlay.SetActive(true);     
    }

}
