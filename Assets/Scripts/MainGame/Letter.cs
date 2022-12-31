using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Letter : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public string letter;
    Image image;
    CanvasGroup canvasGroup;
    Manager manager;
    RectTransform letterPanel;
    RectTransform landingPanel;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        letterPanel = (RectTransform)GameObject.FindGameObjectWithTag("letterbox").transform;
        landingPanel = (RectTransform)GameObject.FindGameObjectWithTag("landing").transform;
        canvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector2(1.2f, 1.2f), 0.2f);
        canvasGroup.blocksRaycasts = false;
        manager.itemBeingDragged = gameObject.GetComponent<Letter>();
        gameObject.GetComponent<Canvas>().overrideSorting = true;
    }

    public void ResetPosition()
    {
        transform.SetParent(letterPanel);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector2(1, 1), 0.2f);

        transform.GetComponent<Image>().raycastTarget = true;
        canvasGroup.blocksRaycasts = true;
        gameObject.GetComponent<Canvas>().overrideSorting = false;
        LayoutRebuilder.MarkLayoutForRebuild(letterPanel);
        LayoutRebuilder.MarkLayoutForRebuild(landingPanel);
    }

}
