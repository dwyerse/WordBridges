using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	string[, ] goalGrid = new string[6, 6];
	public string[, ] currentGrid;
	public List<GameObject> containers;
	public List<GameObject> letterObjects;

	public TextMeshProUGUI title;
	public GameObject letterPrefab;
	public GameObject containerPrefab;
	public GameObject itemBeingDragged;
	public Canvas canvas;
	public GameObject letterPanel;
	public GameObject containerPanel;
	public GameObject correctnessPanel;
	public GameObject correctnessPrefab;
	List<List<int[]>> wordIndexes;
	public CanvasGroup canvasGroup;

	int level;
	int diff = 0;


	// Use this for initialization
	void Start () {

		Application.targetFrameRate = 60;
		wordIndexes = new List<List<int[]>> ();
		if (GameInfo.play == 1) {
			level = 0;
			for (int d = 0; d < 3 && level == 0; d++) {
				if (!PlayerPrefs.HasKey (d + "-" + 1)) {
					level = 1;
					diff = d;
				} else {
					int b = 20;

					for (int i = 0; i < b && level == 0; i++) {

						if (!PlayerPrefs.HasKey (d + "-" + (i + 1))) {
							level = i + 1;
							diff = d;
						}
					}
				}
			}
			if (level == 0) {
				GameInfo.play = 0;
				SceneManager.LoadScene ("DifficultyLevels", LoadSceneMode.Single);
			}
			GameInfo.chosenLevel = level;
			GameInfo.currentDif = diff;
		} else {
			diff = GameInfo.currentDif;
			level = GameInfo.chosenLevel;
		}
		if (level != 0) {
			string methodName = "";
			string diffText = "";
			switch (diff) {
				case 0:
					methodName = "A";
					diffText = "Easy";
					break;
				case 1:
					methodName = "B";
					diffText = "Medium";
					break;
				case 2:
					methodName = "C";
					diffText = "Hard";
					break;
			}

			methodName += level;

			levels l = GameInfo.l;
			MethodInfo mi = l.GetType ().GetMethod (methodName);
			goalGrid = (string[, ]) mi.Invoke (l, null);

			title.text = diffText + " " + level;
			createContainers (goalGrid);
		}
	}

	//On completion of the level.
	void levelComplete () {
		print ("Level Complete");
		canvasGroup.blocksRaycasts = true;
		gameObject.GetComponent<CompleteAnimation> ().startAnimation ();
	}

	void createContainers (string[, ] str) {
		currentGrid = new string[6, 6];
		containers = new List<GameObject> ();
		List<string> letters = new List<string> ();

		int count = 0;
		for (int i = 0; i < str.GetLength (0); i++) {
			List<int[]> word = new List<int[]> ();
			for (int j = 0; j < str.GetLength (1); j++) {
				GameObject container = Instantiate (containerPrefab);
				container.layer = 2;
				container.transform.SetParent (containerPanel.transform);

				if (str[i, j] == null || str[i, j] == "") {
					if (word.Count > 1) {
						wordIndexes.Add (word);
						word = new List<int[]> ();
					} else {
						word.Clear ();
					}

					container.name = "Placeholder";
					Destroy (container.GetComponent<Image> ());
					Destroy (container.GetComponent<Container> ());
				} else {
					container.name = "Container " + count++;
					container.tag = "container";
					containers.Add (container);
					letters.Add (str[i, j]);
					int[] letterIndex = { i, j };
					word.Add (letterIndex);
					container.transform.localScale = new Vector2 (0, 0);
					container.GetComponent<Container> ().i = i;
					container.GetComponent<Container> ().j = j;

					LeanTween.scale (container, new Vector2 (1, 1), 0.5f).setEase (LeanTweenType.easeSpring).setDelay (0.1f * (i + j));
				}
			}
			if (word.Count > 1) {
				wordIndexes.Add (word);
			}
		}

		for (int j = 0; j < str.GetLength (1); j++) {
			List<int[]> word = new List<int[]> ();
			for (int i = 0; i < str.GetLength (0); i++) {
				if (str[i, j] == null || str[i, j] == "") {
					if (word.Count > 1) {
						wordIndexes.Add (word);
						word = new List<int[]> ();
					} else {
						word.Clear ();
					}
				} else {
					int[] letterIndex = { i, j };
					word.Add (letterIndex);
				}
			}
			if (word.Count > 1) {
				wordIndexes.Add (word);
			}
		}

		letters = Shuffle (letters);
		for (int a = 0; a < letters.Count; a++) {
			GameObject letterObject = Instantiate (letterPrefab);
			letterObjects.Add (letterObject);
			letterObject.GetComponent<Letter> ().letter = letters[a];
			letterObject.transform.GetChild (0).GetComponent<TextMeshProUGUI> ().text = letters[a];
			letterObject.transform.SetParent (letterPanel.transform);
			letterObject.transform.localScale = new Vector2 (0, 0);
			LeanTween.scale (letterObject, new Vector2 (1, 1), 1f).setEase (LeanTweenType.easeSpring).setDelay (0.1f * a);
		}
	}

	public List<string> Shuffle (List<string> list) {
		int n = list.Count;
		while (n > 1) {
			n--;
			int k = Random.Range (0, n + 1);
			var value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
		return list;
	}

	public void completeCheck () {
		bool complete = true;
		foreach (Transform child in correctnessPanel.transform) {
			Destroy (child.gameObject);
		}

		foreach (var wordIndex in wordIndexes) {
			string find = "";
			foreach (var index in wordIndex) {
				find += currentGrid[index[0], index[1]];
			}
			find = find.ToLower ();
			if (find.Length == wordIndex.Count) {
				if (!search (find)) {
					Debug.Log (find + " is not a word");
					addToCorrectnessPanel (find.ToUpper (), new Color(0.8f,0.2f,0.2f));
					complete = false;
				} else {
					addToCorrectnessPanel (find.ToUpper (), new Color(0.2f,0.7f,0.2f));
					Debug.Log (find + " is a word");
				}
			} else {
				complete = false;
			}
		}
		if (complete) {
			levelComplete ();
		}

	}

	void addToCorrectnessPanel (string word, Color color) {
		GameObject correctnessText = Instantiate (correctnessPrefab);
		correctnessText.transform.SetParent (correctnessPanel.transform);
		TextMeshProUGUI textMesh = correctnessText.transform.GetChild (0).GetChild (0).GetComponent<TextMeshProUGUI> ();
		textMesh.text = word;
		Correctness correctness = correctnessText.transform.GetChild (0).GetComponent<Correctness> ();
		correctness.animate (color);
	}

	bool search (string str) {
		return GameInfo.wordSet.Contains (str);
	}

}