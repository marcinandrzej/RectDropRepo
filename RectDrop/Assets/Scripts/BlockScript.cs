using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockScript : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameManagerScript gameMan;
    public RectTransform panel;
    public List<GameObject> squares;

    private Vector3 position;

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsInGrid() == true)
        {
            bool play = true;
            for (int i = 0; i < squares.Count; i++)
            {
                if (!CanBePlayed(squares[i]))
                    play = false;
            }
            if (!play)
            {
                Debug.Log("!play");
                gameObject.transform.position = position;
            }
            else
            {
                Debug.Log("play");
                for (int i = 0; i < squares.Count; i++)
                {
                    MarkCell(squares[i]);
                }
                gameMan.CheckGrid(gameObject);
            }
        }
        else
        {
            gameObject.transform.position = position;
        }
    }

    private bool IsInGrid()
    {
        for (int i = 0; i < squares.Count; i++)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(panel, squares[i].transform.position))
                return false;
        }
        return true;
    }

    private bool CanBePlayed(GameObject square)
    {
        List<RaycastResult> hitSquares = new List<RaycastResult>();
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = (square.transform.position);
        EventSystem.current.RaycastAll(pointer, hitSquares);

        if (hitSquares.Count <= 0)
        {
            return false;
        }
        else
        {
            foreach (RaycastResult result in hitSquares)
            {
                if ((result.gameObject.tag == "CELL") && (result.gameObject.GetComponent<SquareScript>().GetColorIndex() == 0))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void MarkCell(GameObject square)
    {
        List<RaycastResult> hitSquares = new List<RaycastResult>();
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = (square.transform.position);
        EventSystem.current.RaycastAll(pointer, hitSquares);

        if (hitSquares.Count > 0)
        {
            foreach (RaycastResult result in hitSquares)
            {
                if (result.gameObject.tag == "CELL")
                {
                    result.gameObject.GetComponent<SquareScript>().SetColor(square.gameObject.GetComponent<SquareScript>().GetColorIndex());
                }
            }
        }
    }

    // Use this for initialization
    void Start ()
    {
        position = gameObject.transform.position;
        foreach (GameObject go in squares)
        {
            go.GetComponent<SquareScript>().SetImage();
            go.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
