using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour {

	string[,] word = new string[6,6];
	List<GameObject> cons;
	List<GameObject> conts;
	public GameObject title;
	public GameObject victoryText;
	public GameObject overlay;
	public GameObject next;
    public GameObject hint;
    public GameObject tutorialObj;
    public GameObject arrow;
    public TextMesh coinsText;
    public Font font;
	float scaler = 0;
	string letters;
	int level;
	int diff = 0;
    
	// Use this for initialization
	void Start () {
       
        
            

        //Set coins value
        coinsText.text = "" + PlayerPrefs.GetInt("coins");

        if (GameInfo.play == 1)
		{
            level = 0;
            for (int d =0;d<3&&level==0;d++) {
                if (!PlayerPrefs.HasKey(d + "-" + 1))
                {
                    level = 1;
                    diff = d;
                }
                else
                {
                    int b = 0;
                    switch (d)
                    {
                        case 0:
                            b = GameInfo.l.easy;
                            break;
                        case 1:
                            b = GameInfo.l.medium;
                            break;
                        case 2:
                            b = GameInfo.l.hard;
                            break;
                    }
                    for (int i = 0; i < b && level==0; i++)
                    {

                        if (!PlayerPrefs.HasKey(d + "-" + (i + 1)))
                        {
                            level = i + 1;
                            diff = d;
                        }
                    }                    
                }
            }
            if (level==0)
            {
                GameInfo.play = 0;
                SceneManager.LoadScene("DifficultyLevels",LoadSceneMode.Single);
            }
            GameInfo.chosenLevel = level;
            GameInfo.currentDif = diff;
        }
		else
		{

            diff = GameInfo.currentDif;
			level = GameInfo.chosenLevel;		   
		}
        if (level != 0)
        {
            string methodName = "";
            string diffText = "";
            switch (diff)
            {
                case 0:
                    methodName = "A";
                    diffText = "EASY";
                    break;
                case 1:
                    methodName = "B";
                    diffText = "MEDIUM";
                    title.transform.position = new Vector2(-0.1f, title.transform.position.y);
                    break;
                case 2:
                    methodName = "C";
                    diffText = "HARD";
                    break;
            }
            
            methodName += level;

            levels l = GameInfo.l;
            MethodInfo mi = l.GetType().GetMethod(methodName);
            word = (string[,])mi.Invoke(l, null);


            title.GetComponent<TextMesh>().text = diffText + " " + level;
            createContainers(word);
            createLetters(word);

            //Tutorial

            int tutorial = 1;
            if (PlayerPrefs.HasKey("tutorial"))
            {                
                tutorial = 0;
            }
            if (tutorial == 1)
            {
                overlay.SetActive(true);
                tutorialObj.SetActive(true);
            }
        }       
    }

	bool completed = false;
	// Update is called once per frame
	void Update () {
        if (level != 0)
        {
            if (!completed && (complete() || alternateComplete()))
            {
                completed = true;
                levelComplete();
            }

            if (scaler < 1)
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    cons[i].transform.localScale = new Vector3(scaler, scaler, scaler);
                    conts[i].transform.localScale = new Vector3(scaler, scaler, scaler);
                }
            }
            scaler += 0.10f;
        }
	}
	//On completion of the level.
	void levelComplete()
	{     

        PlayerPrefs.SetInt("tutorial",1);

        //Add coins if level not complete
        if (!PlayerPrefs.HasKey(diff+"-"+level))
        {
            int c = PlayerPrefs.GetInt("coins");
            c += 7;
            PlayerPrefs.SetInt("coins", c);
        }
        else
        {
            CompleteAnimation.addCoins = false;
        }

        PlayerPrefs.SetInt(diff+"-"+level, 1);
        Destroy(hint.GetComponent<hintButton>());
        GameObject[] hints = GameObject.FindGameObjectsWithTag("hint");
        foreach(GameObject g in hints)
        {
            g.SetActive(false);
        }
        CompleteAnimation.c = true;     
        

	}

 
    void createContainers(string[,] str)
	{
		conts = new List<GameObject>();
		int count = 0;
		for(int i=0;i< str.GetLength(0); i++)
		{
			for (int j = 0; j < str.GetLength(1); j++)
			{
				if (str[i, j] != null&& str[i, j] != "")
				{
					GameObject con = new GameObject();
					
					Vector3 vec = new Vector3(-0.6f+(float)(j*0.6),2f-(float)(i*0.6),0);
					con.GetComponent<Transform>().position = vec;

					con.layer = 2;
					con.AddComponent<SpriteRenderer>();
					con.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/letterbox");
					con.GetComponent<SpriteRenderer>().color = Color.white;
					con.GetComponent<SpriteRenderer>().sortingOrder = -1;
					con.AddComponent<BoxCollider2D>();
					con.AddComponent<containerBehaviour>();
					con.GetComponent<containerBehaviour>().c = str[i, j];
					con.GetComponent<containerBehaviour>().i = i;
					con.GetComponent<containerBehaviour>().j = j;
					con.AddComponent<Rigidbody2D>();
					
					con.name = "con" + count++;
					var rb = con.GetComponent<Rigidbody2D>();
					rb.gravityScale = 0;
					rb.constraints = RigidbodyConstraints2D.FreezeAll;
					con.tag = "container";
					conts.Add(con);
				}
			}
		}
	}

	void createLetters(string[,] str)
	{
		int offset = 0;
		int resetOff = 0;
		int rowOff = 0;
        int co = 0;
		letters = "";
		cons = new List<GameObject>();
		//Box part
		for (int i = 0; i < str.GetLength(0); i++)
		{
			for (int j = 0; j < str.GetLength(1); j++)
			{
				if (str[i, j] != null&&str[i, j] != "")
				{
					GameObject con = new GameObject();
					Vector3 mvec = new Vector3(-0.6f + (float)(resetOff * 0.6), -1.5f + (float)(rowOff * 0.6), 0);
					resetOff++;
                    co++;
					if (co==5)
					{
						rowOff--;
						resetOff = 0;
                        co = 0;
					}                 
					con.name = "letterbox" + offset;
				  
					con.GetComponent<Transform>().position = mvec;
					con.AddComponent<SpriteRenderer>();
					con.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/letterbox");
					con.GetComponent<SpriteRenderer>().color = Color.white;

					con.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    con.tag = "letterbox";
					con.AddComponent<clickControl>();
                    con.GetComponent<clickControl>().tut = tutorialObj;
                    con.GetComponent<clickControl>().tut.GetComponent<Tutorial>().arrow = arrow;
                    con.AddComponent<BoxCollider2D>();
					con.GetComponent<BoxCollider2D>().isTrigger = true;
					con.AddComponent<Rigidbody2D>();
					var rb = con.GetComponent<Rigidbody2D>();
					rb.gravityScale = 0;
					letters += str[i, j];
					
					cons.Add(con);
					offset++;
				}
			}        
		}
		letters = Shuffle(letters);
		resetOff = 0;
		rowOff = 0;

        GameObject[] lets = GameObject.FindGameObjectsWithTag("letter");
        for (int j=0;j<lets.Length;j++)
        {
            lets[j].SetActive(false);
        }
        //Letter Part
        co = 0;
        for (int a=0;a<letters.Length;a++)
		{
            GameObject letter = lets[a];
			letter.name = "letter" + a;
			Vector3 vec = new Vector3(-0.6f + (float)(resetOff * 0.6), -1.53f + (float)(rowOff * 0.6), -1);
			resetOff++;
            co++;
            if (co == 5)
            {
				rowOff--;
				resetOff = 0;
                co = 0;
			}
			letter.GetComponent<Transform>().position = vec;
			letter.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;            
			letter.GetComponent<TextMesh>().characterSize = 0.07f;
			letter.GetComponent<TextMesh>().fontSize = 60;
            letter.transform.SetParent(cons[a].transform);
			letter.GetComponent<TextMesh>().text = letters.Substring(a, 1);
			letter.GetComponent<TextMesh>().color = new Color32(0x02, 0x78, 0xfd, 0xFF); 
             GameObject q = cons[a];
			q.transform.localScale = new Vector3(0, 0, 0);
            
            letter.SetActive(true);
		}		
	}

	public string Shuffle(string str)
	{
		char[] array = str.ToCharArray();
		int n = array.Length;
		while (n > 1)
		{
			n--;
			int k = UnityEngine.Random.Range(0,n + 1);
			var value = array[k];
			array[k] = array[n];
			array[n] = value;
		}
		return new string(array);
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

	bool alternateComplete()
	{

		if (containersFull())
		{
			for (int i = 0; i < word.GetLength(0); i++)
			{
				for (int j = 0; j < word.GetLength(1); j++)
				{
					string find = "";
					if (word[i, j] != null)
					{
						while (i < word.GetLength(0) && j < word.GetLength(1) && word[i, j] != null)
						{
							find += GameInfo.grid[i, j];
                            j++;
						}
						find = find.ToLower();
                        
                        if (!search(GameInfo.l.file,find)&&find.Length>1)
						{
                            Debug.Log("Fail: " + find);
                            return false;
						}
					}
				}
			}
			for (int j = 0; j < word.GetLength(1); j++)
			{
				for (int i = 0; i < word.GetLength(0); i++)
				{
				
					string find = "";
					if (word[i, j] != null)
					{
						while (i < word.GetLength(0) && j < word.GetLength(1) && word[i, j] != null)
						{
							find += GameInfo.grid[i, j];
							i++;
						}
						find = find.ToLower();
						
						if (!search(GameInfo.l.file, find) && find.Length > 1)
						{
                            Debug.Log("Fail: " + find);
							return false;
						}
					}
				}
			}
			return true;
		}
		return false;
	}


	bool containersFull()
	{
		GameObject[] containers = GameObject.FindGameObjectsWithTag("container");

		for (int i = 0; i < containers.Length; i++)
		{
			containerBehaviour con = containers[i].transform.GetComponent<containerBehaviour>();
			if (con.occupant==null)
			{
				return false;
			}
		}
		return true;
	}

    bool search(string[] arr,string str)
    {

        for (int i=0;i<arr.Length;i++)
        {
            if (str.Equals(arr[i].Trim()))
            {
                return true;
            }
        }

        return false;
    }

}
