using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Letter : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {
    public string letter;
    Image image;
    CanvasGroup canvasGroup;
    Manager manager;
    RectTransform letterPanel;
    RectTransform landingPanel;
    public Color highlight;
    Color originalColor;
    bool isLocked = false;

    public void Start() {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        letterPanel = (RectTransform)GameObject.FindGameObjectWithTag("letterbox").transform;
        landingPanel = (RectTransform)GameObject.FindGameObjectWithTag("landing").transform;
        canvasGroup = GetComponent<CanvasGroup>();
        image = GetComponent<Image>();
        originalColor = image.color;
    }

    public void Lock() {
        isLocked = true;
    }

    public void OnDrag(PointerEventData eventData) {
        if (!isLocked) {
            gameObject.transform.position = eventData.position;
            gameObject.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (!isLocked) {
            transform.DOScale(new Vector2(1.2f, 1.2f), 0.2f);
            transform.GetComponent<Image>().DOColor(highlight, 0.2f);

            canvasGroup.blocksRaycasts = false;
            manager.itemBeingDragged = gameObject.GetComponent<Letter>();
            gameObject.GetComponent<Canvas>().overrideSorting = true;
        }
    }

    public void ResetPosition() {
        if (!isLocked) {
            transform.SetParent(letterPanel);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.DOScale(new Vector2(1f, 1f), 0.2f);
        transform.GetComponent<Image>().DOColor(originalColor, 0.2f);

        transform.GetComponent<Image>().raycastTarget = true;
        canvasGroup.blocksRaycasts = true;
        gameObject.GetComponent<Canvas>().overrideSorting = false;
        LayoutRebuilder.MarkLayoutForRebuild(letterPanel);
        LayoutRebuilder.MarkLayoutForRebuild(landingPanel);
    }

}
