using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class LevelModel {
    public string levelName;
    public string[,] letters;
    public string ID;

    private List<string> GetHorizontalWords(string[,] letters) {
        List<string> wordList = new();
        for (int i = 0; i < letters.GetLength(0); i++) {
            string currentWord = "";
            for (int j = 0; j < letters.GetLength(1); j++) {
                if (letters[i, j] == "") {
                    if (currentWord.Length > 1) {
                        wordList.Add(currentWord);
                    }
                    currentWord = "";
                } else {
                    currentWord += letters[i, j];
                }
            }
            if (currentWord.Length > 1) {
                wordList.Add(currentWord);
            }
        }

        return wordList;
    }

    private List<string> GetVerticalWords(string[,] letters) {
        List<string> wordList = new();
        for (int i = 0; i < letters.GetLength(0); i++) {
            string currentWord = "";
            for (int j = 0; j < letters.GetLength(1); j++) {
                if (letters[j, i] == "") {
                    if (currentWord.Length > 1) {
                        wordList.Add(currentWord);
                    }
                    currentWord = "";
                } else {
                    currentWord += letters[j, i];
                }
            }
            if (currentWord.Length > 1) {
                wordList.Add(currentWord);
            }
        }

        return wordList;
    }

    public List<string> GetWords(string[,] letters) {
        List<string> horizontalWords = GetHorizontalWords(letters);
        List<string> verticalWords = GetVerticalWords(letters);
        List<string> combinedWords = new();
        combinedWords.AddRange(horizontalWords);
        combinedWords.AddRange(verticalWords);
        return combinedWords;
    }

    public bool IsSolvable() {
        bool IsSolvable = true;
        var words = GetWords(letters);
        foreach (var word in words) {
            if (!GameInfo.wordSet.Contains(word.ToLower())) {
                Debug.Log(word);
                IsSolvable = false;
            }
        }

        return IsSolvable;
    }

    public string GetShareableString() {
        string share = "";
        for (int i = 0; i < letters.GetLength(0); i++) {
            for (int j = 0; j < letters.GetLength(1); j++) {
                share += letters[i, j] + ",";
            }
        }
        share += levelName;
        string base64share = Convert.ToBase64String(Encoding.UTF8.GetBytes(share));
        return base64share;
    }
}