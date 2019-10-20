using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Letter : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {
    public Vector3 startPosition;
    public String letter;
    Shadow shadow;
    Image image;
    CanvasGroup canvasGroup;
    Transform startParent;
    Manager manager;

    void Start () {
        startPosition = transform.position;
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        canvasGroup = GetComponent<CanvasGroup>();     
        shadow = GetComponent<Shadow>();
        image = GetComponent<Image>();

    }
  
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
        gameObject.GetComponent<Image>().raycastTarget = false;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {   
        LeanTween.scale(gameObject, new Vector2(1.5f, 1.5f), 0.2f);
        LeanTween.value(gameObject,updateShadow, shadow.effectDistance,new Vector2(10.0f, -10.0f), 0.1f);

        canvasGroup.blocksRaycasts = false;
        startParent = transform.parent;
        startPosition = transform.position;
        manager.itemBeingDragged = gameObject;
        gameObject.GetComponent<Canvas>().overrideSorting = true;
    }

    void updateShadow(Vector2 effectDistance)
    {
        shadow.effectDistance = effectDistance;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector2(1, 1), 0.2f);
        LeanTween.value(gameObject, updateShadow, shadow.effectDistance, new Vector2(0.0f, 0.0f), 0.1f);

        if (transform.parent == startParent)
        {
            LeanTween.move(gameObject, startPosition, 0.3f).setOnComplete(overrideSorting);
        }
        else
        {
            overrideSorting();
        }
        canvasGroup.blocksRaycasts = true;
    }

    void overrideSorting()
    {
        gameObject.GetComponent<Canvas>().overrideSorting = false;
    }
}
