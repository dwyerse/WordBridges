using TMPro;
using UnityEngine;

public class DifficultyTitle : MonoBehaviour
{

    TextMeshProUGUI title;

    public void Start()
    {
        int diff = GameInfo.currentDiff;
        title = GetComponent<TextMeshProUGUI>();
        switch (diff)
        {
            case 0:
                title.text = "EASY";
                break;
            case 1:
                title.text = "MEDIUM";
                break;
            case 2:
                title.text = "HARD";
                break;
        }
    }
}
