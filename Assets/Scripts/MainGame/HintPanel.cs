using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintPanel : MonoBehaviour {
    public GameObject prefab;

    public void Add(string word, Color color) {
        GameObject hintText = Instantiate(prefab);
        hintText.transform.SetParent(transform);
        TextMeshProUGUI textMesh = hintText.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMesh.text = word;
        Image hint = hintText.GetComponent<Image>();
        hintText.transform.localScale = new Vector2(1, 1);
        hint.color = color;
    }

    public void Clear() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

}