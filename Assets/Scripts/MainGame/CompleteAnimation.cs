using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class CompleteAnimation : MonoBehaviour {
    public static bool c = false;
    List<GameObject> containers;
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
        containers = manager.containers;
    }

    // Update is called once per frame

    public void startAnimation()
    {
        for (int i = 0; i < containers.Count; i++)
        {
            LeanTween.color(containers[i], new Color(50, 50, 255), 0.5f).setOnComplete(phase2);
        }
    }

    void phase2()
    {
        hideLetters();
        for (int i = 0; i < containers.Count; i++)
        {
            LeanTween.move(containers[i], new Vector2(0.5f, 0.5f), 0.5f);
        }
    }
 

    public void showCompletePanel()
    {        
            victoryText.SetActive(true);
            next.SetActive(true);
            overlay.SetActive(true);     
    }

    public void hideLetters()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].SetActive(false);
        }
    }

}
