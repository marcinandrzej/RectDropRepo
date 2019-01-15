using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockScript : MonoBehaviour, IDropHandler, IDragHandler
{
    public RectTransform panel;
    private Vector3 position;

    public List<GameObject> images;

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!IsInGrid())
            gameObject.transform.position = position;
    }

    private bool IsInGrid()
    {
        foreach (GameObject img in images)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(panel, img.transform.position))
                return false;
        }
        return true;
    }

    // Use this for initialization
    void Start ()
    {
        position = gameObject.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
