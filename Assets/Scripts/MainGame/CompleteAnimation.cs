using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class CompleteAnimation : MonoBehaviour {
    public static bool c = false;
    GameObject[] containers;
    public GameObject victoryText;
    public GameObject overlay;
    public GameObject next;
    public Transform extra;
    Transform last;
    public TextMesh coins;
    public float speed = 0.04f;
    public float colorSpeed = 0.04f;
    int phase;
    int colorPhase;
    public static bool addCoins = true;
    // Use this for initialization
    void Start () {
        phase = 0;
        colorPhase = 0;
        c = false;
        containers = GameObject.FindGameObjectsWithTag("container");
    }
	
	// Update is called once per frame
	void Update () {
        if (c)
        {
            if (phase == 0)
            {
                containers = GameObject.FindGameObjectsWithTag("letterbox");
                for (int i = 0; i < containers.Length; i++)
                {
                    SpriteRenderer sp = containers[i].GetComponent<SpriteRenderer>();
                    if (colorPhase == 0)
                    {
                        if (sp.color.r>0.5) {
                            sp.color = new Color(sp.color.r- colorSpeed, sp.color.g, sp.color.b - colorSpeed);
                        }
                        else
                        {
                            colorPhase = 1;
                        }
                    }
                    else if (colorPhase == 1)
                    {
                        if (sp.color.r < 1)
                        {
                            sp.color = new Color(sp.color.r+ colorSpeed, sp.color.g , sp.color.b + colorSpeed);
                        }
                        else
                        {
                            phase = 1;
                        }
                    }
                    
                }
            }
            else if (phase == 1) {
                containers = GameObject.FindGameObjectsWithTag("container");
                hideLetters();
                for (int i = 0; i < containers.Length; i++)
                {
                    Transform t = containers[i].transform;
                    if (t.position.x<0.6f||t.position.x>0.6f + speed)
                    {
                        if (t.position.x < 0.6f)
                        {
                            t.position = new Vector3(t.position.x + speed, t.position.y, t.position.z);
                        }
                        else if (t.position.x > 0.6f + speed)
                        {
                            t.position = new Vector3(t.position.x - speed, t.position.y, t.position.z);
                        }

                        if (t.position.x > 0.6f && t.position.x < 0.6f + speed)
                        {
                            t.position = new Vector3(0.6f, t.position.y, t.position.z);
                        }

                    }
                    else if (t.position.y > 0||t.position.y< -speed)
                    {   
                        if(t.position.y > 0)
                        {
                            t.position = new Vector3(t.position.x, t.position.y - speed, t.position.z);
                        }
                        else if (t.position.y < speed)
                        {
                            t.position = new Vector3(t.position.x, t.position.y + speed, t.position.z);
                        }

                        if (t.position.y < 0 && t.position.y > -speed)
                        {
                            t.position = new Vector3(t.position.x, 0, t.position.z);
                            if (i ==0)
                            {
                                phase = 2;
                                //showCompletePanel();
                            }
                        }
                    }
                }
            }
            else if (phase==2)
            {
                int i = 0;
                for (i = 0; i < containers.Length-1; i++)
                {
                    containers[i].SetActive(false);
                }
                last = containers[i].transform;
                phase = 3;
            }
            else if (phase ==3)
            {
                if (last.localScale.x>0 && last.localScale.y > 0) {
                    last.localScale = new Vector3(last.localScale.x - 0.06f, last.localScale.y - 0.06f, last.localScale.z);
                }
                else
                {
                    last.localScale = new Vector3(0,0,0);
                    if (extra.localScale.x<1)
                    {
                        if (addCoins)
                        {
                            extra.localScale = new Vector3(extra.localScale.x + 0.06f, extra.localScale.y + 0.06f, extra.localScale.z);
                        }
                        else
                        {
                            phase = 6;
                            showCompletePanel();
                        }
                    }
                    else
                    {                        
                            phase = 4;                        
                            showCompletePanel();
                    }                    
                }
            }
            else if (phase==4)
            {
                if (extra.position.x > -0.65)
                {
                    extra.position = new Vector3(extra.position.x - 0.034f, extra.position.y, extra.position.z);
                }
                if (extra.position.y < 2.2)
                {
                    extra.position = new Vector3(extra.position.x , extra.position.y + 0.06f, extra.position.z);
                }
                if(extra.position.x<=-0.65 && extra.position.y <= 2.5)
                {
                    extra.localScale = new Vector3(0, 0, 0);
                   
                    phase = 5;
                }
            }
            else if (phase == 5)
            {
                StartCoroutine(countUp());
                phase = 6;                             
            }
            else if (phase==6)
            {
                if (PlayerPrefs.HasKey("howManyAds"))
                {
                    int ads = PlayerPrefs.GetInt("howManyAds");
                    ads++;
                    PlayerPrefs.SetInt("howManyAds",ads);
                }
                else
                {
                    PlayerPrefs.SetInt("howManyAds", 1);
                }

                if (Advertisement.IsReady() && (PlayerPrefs.GetInt("howManyAds")%3==0) && !PlayerPrefs.HasKey("BlockAds"))
                {
                    //Advertisement.Show();
                }
                phase = 7;
            }
        }
	}   

    IEnumerator countUp()
    {
        int cv = int.Parse(coins.text);
        int pCoins = PlayerPrefs.GetInt("coins");
        for (int i = 0; i + cv <= pCoins; i++)
        {
            coins.text = "" + (cv + i);
            yield return new WaitForSeconds(0.1f);
        }     
    }
    public void showCompletePanel()
    {        
            victoryText.SetActive(true);
            next.SetActive(true);
            overlay.SetActive(true);     
    }
    public static void hideLetters()
    {
        GameObject[] letters = GameObject.FindGameObjectsWithTag("letterbox");
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].SetActive(false);
        }
    }

}
