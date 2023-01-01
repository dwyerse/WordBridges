using System.Collections.Generic;
using UnityEngine;
public class Starting : MonoBehaviour
{

    public void Start()
    {
        if (GameInfo.wordSet == null)
        {
            GameInfo.wordSet = new HashSet<string>();
            TextAsset txt = (TextAsset)Resources.Load("unixdict", typeof(TextAsset));
            string[] words = txt.text.Split('\n');
            foreach (string word in words)
            {
                GameInfo.wordSet.Add(word.Trim());
            }
        }

    }
}