using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelModel
{
    public string levelName;
    public string[,] letters;
    public string ID;

    private List<string> GetHorizontalWords()
    {
        List<string> wordList = new();
        for (int i = 0; i < letters.GetLength(0); i++)
        {
            string currentWord = "";
            for (int j = 0; j < letters.GetLength(1); j++)
            {
                if (letters[i, j] == "")
                {
                    if (currentWord.Length > 1)
                    {
                        wordList.Add(currentWord);
                    }
                    currentWord = "";
                }
                else
                {
                    currentWord += letters[i, j];
                }
            }
            if (currentWord.Length > 1)
            {
                wordList.Add(currentWord);
            }
        }

        return wordList;
    }

    private List<string> GetVerticalWords()
    {
        List<string> wordList = new();
        for (int i = 0; i < letters.GetLength(0); i++)
        {
            string currentWord = "";
            for (int j = 0; j < letters.GetLength(1); j++)
            {
                if (letters[j, i] == "")
                {
                    if (currentWord.Length > 1)
                    {
                        wordList.Add(currentWord);
                    }
                    currentWord = "";
                }
                else
                {
                    currentWord += letters[j, i];
                }
            }
            if (currentWord.Length > 1)
            {
                wordList.Add(currentWord);
            }
        }

        return wordList;
    }

    public List<string> GetWords()
    {
        List<string> horizontalWords = GetHorizontalWords();
        List<string> verticalWords = GetVerticalWords();
        List<string> combinedWords = new();
        combinedWords.AddRange(horizontalWords);
        combinedWords.AddRange(verticalWords);
        return combinedWords;
    }

    public bool IsSolvable()
    {
        bool IsSolvable = true;
        var words = GetWords();
        foreach (var word in words)
        {
            if (!GameInfo.wordSet.Contains(word.ToLower()))
            {
                Debug.Log(word);
                IsSolvable = false;
            }
        }

        return IsSolvable;
    }

}