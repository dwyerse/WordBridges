using UnityEngine;
using UnityEngine.EventSystems;

public class Container : MonoBehaviour, IDropHandler
{

    public string goalLetter;
    Manager manager;
    public int i;
    public int j;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("OnDrop : " + eventData);
        Letter beingDragged = manager.itemBeingDragged;
        if (transform.childCount == 0)
        {
            Container swappedContainer = beingDragged.transform.parent.GetComponent<Container>();
            if (swappedContainer != null)
            {
                manager.currentGrid[swappedContainer.i, swappedContainer.j] = null;
            }
            beingDragged.transform.SetParent(transform);
        }
        else
        {
            Letter current = transform.GetChild(0).GetComponent<Letter>();
            Letter updated = beingDragged;
            SwapLetters(current, updated);
        }
        manager.currentGrid[i, j] = beingDragged.GetComponent<Letter>().letter;
        manager.CompleteCheck();
    }

    public void SwapLetters(Letter current, Letter updated)
    {
        current.transform.SetParent(updated.transform.parent);
        Container sourceContainer = updated.transform.parent.GetComponent<Container>();
        if (sourceContainer != null)
        {
            int containerX = sourceContainer.i;
            int containerY = sourceContainer.j;
            manager.currentGrid[containerX, containerY] = current.letter;
        }
        updated.transform.SetParent(transform);
    }


}
