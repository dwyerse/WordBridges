using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Letter : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public string letter;
    Image image;
    CanvasGroup canvasGroup;
    Manager manager;
    Transform letterPanel;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
        letterPanel = GameObject.FindGameObjectWithTag("letterbox").transform;
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
        print("DragEnd : " + eventData);
        LeanTween.scale(gameObject, new Vector2(1, 1), 0.2f);

        overrideSorting();

        canvasGroup.blocksRaycasts = true;
    }

    void overrideSorting()
    {
        gameObject.GetComponent<Canvas>().overrideSorting = false;
    }
}
