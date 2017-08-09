using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Advertisements;

public class manager : MonoBehaviour {

	string[,] word = new string[6,6];
	List<GameObject> cons;
	List<GameObject> conts;
	public GameObject title;
	public GameObject victoryText;
	public GameObject overlay;
	public GameObject next;
    public GameObject hint;
    public TextMesh coinsText;
	float scaler = 0;
	string letters;
	int level = 1;
	int diff = 0;
	// Use this for initialization
	void Start () {

        if (Advertisement.IsReady())
        {
            //Advertisement.Show();
        }
        else
        {
        }
        

        //Set coins value
        coinsText.text = "" + PlayerPrefs.GetInt("coins");

        if (GameInfo.play == 1)
		{

			if (PlayerPrefs.HasKey("level"))
			{
				level = PlayerPrefs.GetInt("level");
			}
			else
			{
				PlayerPrefs.SetInt("level", 1);
			}
			if (PlayerPrefs.HasKey("diff"))
			{
				diff = PlayerPrefs.GetInt("diff");
			}
			else
			{
				PlayerPrefs.SetInt("diff", 0);
			}

		}
		else
		{            			
			diff = GameInfo.currentDif;
			level = GameInfo.chosenLevel;		   
		}
		string methodName = "";
		switch (diff)
		{
			case 0:
				methodName = "A";
				break;
			case 1:
				methodName = "B";
				break;
			case 2:
				methodName = "C";
				break;
		}
		methodName += level;
		levels l = GameInfo.l;
		MethodInfo mi = l.GetType().GetMethod(methodName);
		word = (string[,])mi.Invoke(l, null);
		title.GetComponent<TextMesh>().text = "LEVEL " + GameInfo.chosenLevel;
		createContainers(word);
		createLetters(word);
	}

	bool completed = false;
	// Update is called once per frame
	void Update () {
		
		if (!completed&&(complete()|| alternateComplete()))
		{
			completed = true;
			levelComplete();
		}

		if (scaler < 1)
		{
			for (int i=0;i<letters.Length;i++)
			{
				cons[i].transform.localScale = new Vector3(scaler, scaler, scaler);
				conts[i].transform.localScale = new Vector3(scaler, scaler, scaler);
			}
		}
		scaler += 0.10f;
	}
	//On completion of the level.
	void levelComplete()
	{	
		PlayerPrefs.SetInt(diff+"-"+level, 1);
        Destroy(hint.GetComponent<hintButton>());

        CompleteAnimation.c = true;

        //Add coins
        int c = PlayerPrefs.GetInt("coins");
        c += 7;
        PlayerPrefs.SetInt("coins", c);

	}

 
    void createContainers(string[,] str)
	{
		conts = new List<GameObject>();
		int count = 0;
		for(int i=0;i< str.GetLength(0); i++)
		{
			for (int j = 0; j < str.GetLength(1); j++)
			{
				if (str[i, j] != null)
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
		letters = "";
		cons = new List<GameObject>();
		//Box part
		for (int i = 0; i < str.GetLength(0); i++)
		{
			for (int j = 0; j < str.GetLength(1); j++)
			{
				if (str[i, j] != null)
				{
					GameObject con = new GameObject();
					Vector3 vec = new Vector3(-0.6f + (float)(resetOff * 0.6), -1.5f + (float)(rowOff * 0.6), 0);
					resetOff++;
					if (offset % 4 == 0 && offset!=0)
					{
						rowOff--;
						resetOff = 0;
					}                 
					con.name = "letterbox" + offset;
				  
					con.GetComponent<Transform>().position = vec;
					con.AddComponent<SpriteRenderer>();
					con.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/letterbox");
					con.GetComponent<SpriteRenderer>().color = Color.white;
					con.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    con.tag = "letterbox";
					con.AddComponent<clickControl>();
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

		//Letter Part
		for (int a=0;a<letters.Length;a++)
		{
			GameObject letter = new GameObject();
			letter.name = "letter" + a;
			Vector3 vec = new Vector3(-0.6f + (float)(resetOff * 0.6), -1.5f + (float)(rowOff * 0.6), -1);
			resetOff++;
			if (a % 4 == 0 && a != 0)
			{
				rowOff--;
				resetOff = 0;
			}
			letter.GetComponent<Transform>().position = vec;
			letter.AddComponent<TextMesh>();
			letter.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;            
			letter.GetComponent<TextMesh>().characterSize = 0.06f;
			letter.GetComponent<TextMesh>().fontSize = 60; 
			letter.transform.SetParent(cons[a].transform);
			letter.GetComponent<TextMesh>().text = letters.Substring(a, 1);
			letter.GetComponent<TextMesh>().color = new Color32(0x30, 0x7B, 0xB0, 0xFF);
			GameObject q = cons[a];
			q.transform.localScale = new Vector3(0, 0, 0);
				   
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
