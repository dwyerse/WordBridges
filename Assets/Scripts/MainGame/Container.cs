using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Container : MonoBehaviour, IDropHandler
{

	public string goalLetter;
	Manager manager;
	public int i;
	public int j;
	// Use this for initialization
	void Start () {
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<Manager>();

	}
	
	public void OnDrop(PointerEventData eventData)
	{
		GameObject beingDragged = manager.itemBeingDragged;
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
			Letter swappedLetter = transform.GetChild(0).GetComponent<Letter>();
			swappedLetter.transform.SetParent(beingDragged.transform.parent);
			Container swappedContainer = beingDragged.transform.parent.GetComponent<Container>();
			if (swappedContainer != null)
			{
				manager.currentGrid[swappedContainer.i, swappedContainer.j] = swappedLetter.letter;
			}
			beingDragged.transform.SetParent(transform);
			
		}
		manager.currentGrid[i, j] = beingDragged.GetComponent<Letter>().letter;
		manager.completeCheck();
	}
}
