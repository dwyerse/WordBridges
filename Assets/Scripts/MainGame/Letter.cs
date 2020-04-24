using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Coffee.UIExtensions;
public class Letter : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {
    public Vector3 startPosition;
    public string letter;
    UIShadow shadow;
    Image image;
    CanvasGroup canvasGroup;
    Transform startParent;
    Manager manager;

    void Start () {
        startPosition = transform.position;
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        canvasGroup = GetComponent<CanvasGroup>();     
        shadow = GetComponent<UIShadow>();
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

    public void ResetPosition()
    {
        LeanTween.move(gameObject, startPosition, 0.3f).setOnComplete(overrideSorting);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector2(1, 1), 0.2f);

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
