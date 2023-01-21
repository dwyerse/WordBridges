using System.Collections.Generic;
using System.Reflection;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    string[,] goalGrid = new string[6, 6];
    public string[,] currentGrid;
    public List<GameObject> containers;
    public List<GameObject> letterObjects;

    public TextMeshProUGUI title;
    public GameObject letterPrefab;
    public GameObject landingPrefab;
    public GameObject containerPrefab;
    public Letter itemBeingDragged;
    public Canvas canvas;
    public GameObject letterPanel;
    public GameObject containerPanel;
    public GameObject landingPanel;
    List<List<int[]>> wordIndexes;
    public CanvasGroup canvasGroup;
    public HintPanel hintPanel;

    public void Start()
    {
        hintPanel = GameObject.Find("HintPanel").GetComponent<HintPanel>();
        wordIndexes = new List<List<int[]>>();
        Dictionary<string, LevelModel> levels;
        if (GameInfo.gameMode == GameInfo.GameMode.Custom)
        {
            levels = GameInfo.customLevels.levels;
        }
        else
        {
            levels = GameInfo.standardLevels.levels;
        }

        LevelModel levelModel = levels[GameInfo.level];

        goalGrid = levelModel.letters;
        CreateContainers(goalGrid);
        CreateLandingPanel(goalGrid);
    }

    void LevelComplete()
    {
        foreach (GameObject letter in letterObjects)
        {
            letter.GetComponent<Letter>().Lock();
        }
        gameObject.GetComponent<CompleteAnimation>().StartAnimation();
    }

    public void Next()
    {
        SceneManager.LoadScene("WordBridges");
    }

    public void Restart()
    {
        for (int a = 0; a < letterObjects.Count; a++)
        {
            letterObjects[a].GetComponent<Letter>().ResetPosition();
        }

        currentGrid = new string[6, 6];
        CompleteCheck();

    }

    void CreateLandingPanel(string[,] str)
    {

        for (int i = 0; i < str.GetLength(0); i++)
        {
            for (int j = 0; j < str.GetLength(1); j++)
            {
                if (str[i, j] == null || str[i, j] == "")
                {
                    GameObject container = Instantiate(landingPrefab);
                    container.layer = 2;
                    container.transform.SetParent(landingPanel.transform);
                    container.tag = "container";
                    container.name = "Landing " + i + j;
                    Destroy(container.GetComponent<Image>());
                    Destroy(container.GetComponent<Container>());
                    Destroy(container.GetComponent<CanvasRenderer>());
                    Destroy(container.GetComponent<GridLayoutGroup>());
                }
                else
                {
                    GameObject container = Instantiate(landingPrefab);
                    container.layer = 2;
                    container.transform.SetParent(landingPanel.transform);
                    container.tag = "container";
                    container.name = "Landing " + i + j;
                    container.GetComponent<Container>().i = i;
                    container.GetComponent<Container>().j = j;
                    container.transform.localScale = new Vector2(1, 1);

                }
            }
        }
    }

    void CreateContainers(string[,] str)
    {
        currentGrid = new string[6, 6];
        containers = new List<GameObject>();
        List<string> letters = new();

        int count = 0;
        for (int i = 0; i < str.GetLength(0); i++)
        {
            List<int[]> word = new();
            for (int j = 0; j < str.GetLength(1); j++)
            {
                GameObject container = Instantiate(containerPrefab);
                container.layer = 2;
                container.transform.SetParent(containerPanel.transform);

                if (str[i, j] == null || str[i, j] == "")
                {
                    if (word.Count > 1)
                    {
                        wordIndexes.Add(word);
                        word = new List<int[]>();
                    }
                    else
                    {
                        word.Clear();
                    }

                    container.name = "Placeholder";
                    Destroy(container.GetComponent<Image>());
                    Destroy(container.GetComponent<Container>());
                    Destroy(container.GetComponent<CanvasRenderer>());
                    Destroy(container.GetComponent<GridLayoutGroup>());

                }
                else
                {
                    container.name = "Container " + count++;
                    containers.Add(container);
                    letters.Add(str[i, j]);
                    int[] letterIndex = { i, j };
                    word.Add(letterIndex);
                    container.transform.localScale = new Vector2(0, 0);
                    Destroy(container.GetComponent<Container>());
                    container.transform.DOScale(new Vector2(1, 1), 0.5f).SetEase(Ease.InOutCubic).SetDelay(0.1f * (i + j));
                }
            }
            if (word.Count > 1)
            {
                wordIndexes.Add(word);
            }
        }

        for (int j = 0; j < str.GetLength(1); j++)
        {
            List<int[]> word = new();
            for (int i = 0; i < str.GetLength(0); i++)
            {
                if (str[i, j] == null || str[i, j] == "")
                {
                    if (word.Count > 1)
                    {
                        wordIndexes.Add(word);
                        word = new List<int[]>();
                    }
                    else
                    {
                        word.Clear();
                    }
                }
                else
                {
                    int[] letterIndex = { i, j };
                    word.Add(letterIndex);
                }
            }
            if (word.Count > 1)
            {
                wordIndexes.Add(word);
            }
        }

        CreateLetters(letters);

    }

    void CreateLetters(List<string> letters)
    {
        letters = Shuffle(letters);
        for (int a = 0; a < letters.Count; a++)
        {
            GameObject letterObject = Instantiate(letterPrefab);
            letterObjects.Add(letterObject);
            letterObject.name = "" + letters[a];
            letterObject.GetComponent<Letter>().letter = letters[a];
            letterObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = letters[a];
            letterObject.transform.SetParent(letterPanel.transform);
            letterObject.transform.localScale = new Vector2(0, 0);
            letterObject.transform.DOScale(new Vector2(1, 1), 1f).SetEase(Ease.InOutCubic).SetDelay(a * 0.1f);
        }
    }

    public List<string> Shuffle(List<string> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
        return list;
    }

    public void CompleteCheck()
    {
        hintPanel.Clear();
        bool complete = true;

        foreach (var wordIndex in wordIndexes)
        {
            string find = "";
            foreach (var index in wordIndex)
            {
                find += currentGrid[index[0], index[1]];
            }
            find = find.ToLower();
            if (find.Length == wordIndex.Count)
            {
                if (!GameInfo.wordSet.Contains(find))
                {
                    hintPanel.Add(find.ToUpper(), new Color(0.8f, 0.3f, 0.3f));
                    complete = false;
                }
                else
                {
                    hintPanel.Add(find.ToUpper(), new Color(0.3f, 0.7f, 0.3f));
                }
            }
            else
            {
                complete = false;
            }
        }
        if (complete)
        {
            LevelComplete();
        }
    }
}