using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class manager : MonoBehaviour {

	string[,] word = new string[6,6];
	List<GameObject> cons;
	List<GameObject> conts;
	public GameObject title;
	float scaler = 0;
	string letters;
	// Use this for initialization
	void Start () {
		int level = 1;
		if (PlayerPrefs.HasKey("level"))
		{
			level = PlayerPrefs.GetInt("level");
		}
		else
		{
			PlayerPrefs.SetInt("level",1);
		}
	   
		levels l = new levels();

		string methodName = "A" + level;

		switch (GameInfo.currentDif)
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
        Debug.Log(GameInfo.chosenLevel);
        methodName += GameInfo.chosenLevel;

		Debug.Log(methodName);
		MethodInfo mi = l.GetType().GetMethod(methodName);
		word = (string[,])mi.Invoke(l, null);
		title.GetComponent<TextMesh>().text = "LEVEL " + level;
		createContainers(word);
		createLetters(word);
	}
	bool completed = false;
	// Update is called once per frame
	void Update () {
		if (complete()&&!completed)
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
	//On completion of the level, a box appears.
	void levelComplete()
	{
		GameObject cS = new GameObject();
		Vector3 vec = new Vector3(0.55f, 0, 0);
		cS.GetComponent<Transform>().position = vec;
		cS.AddComponent<SpriteRenderer>();
		cS.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/letterbox");
		cS.GetComponent<SpriteRenderer>().color = Color.grey;
		cS.GetComponent<SpriteRenderer>().sortingOrder = 2;
		cS.transform.localScale = new Vector3(5,7,1);
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
					con.GetComponent<SpriteRenderer>().color = Color.grey;
					con.GetComponent<SpriteRenderer>().sortingOrder = -1;
					con.AddComponent<BoxCollider2D>();
					con.AddComponent<containerBehaviour>();
					con.GetComponent<containerBehaviour>().c = str[i, j];
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
					con.GetComponent<SpriteRenderer>().color = Color.grey;
					con.GetComponent<SpriteRenderer>().sortingOrder = 0;
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
			TextMesh textMesh = letter.AddComponent<TextMesh>();
			letter.GetComponent<TextMesh>().anchor = TextAnchor.MiddleCenter;            
			letter.GetComponent<TextMesh>().characterSize = 0.06f;
			letter.GetComponent<TextMesh>().fontSize = 60;
			//letter.GetComponent<TextMesh>().font = Resources.Load<Font>("Fonts/Composition");  
			letter.transform.SetParent(cons[a].transform);
			letter.GetComponent<TextMesh>().text = letters.Substring(a, 1);
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
			int k = Random.Range(0,n + 1);
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

}
