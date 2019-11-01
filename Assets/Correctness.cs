using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Correctness : MonoBehaviour
{
    Image image;

    void Start()
    {
        
    }

    void updateColor(Color color)
    {
        image.color = color;
    }

    public void animate(Color newColor)
    {
        image = GetComponent<Image>();
        LeanTween.value(gameObject, updateColor, image.color, newColor, 0.5f);
    }
}