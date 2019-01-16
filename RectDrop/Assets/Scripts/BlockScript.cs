using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockScript : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private GameManagerScript gameMan;
    private RectTransform gridPanel;
    private List<GameObject> squares;

    private Vector3 position;
    private int startPosition;

    public void SetBlock(GameManagerScript _gmeMan, RectTransform _gridPanel, int _startPosition)
    {
        squares = new List<GameObject>();
        gameMan = _gmeMan;
        gridPanel = _gridPanel;
        startPosition = _startPosition;
        position = gameObject.transform.position;
    }

    public void AddSquare(GameObject square)
    {
        squares.Add(square);
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsInGrid())
        {
            bool play = true;
            for (int i = 0; i < squares.Count; i++)
            {
                if (!CanBePlayed(squares[i]))
                    play = false;
            }
            if (!play)
            {
                gameObject.transform.position = position;
            }
            else
            {
                for (int i = 0; i < squares.Count; i++)
                {
                    MarkCell(squares[i]);
                }
                gameMan.CheckGrid(gameObject, startPosition);
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
            if (!RectTransformUtility.RectangleContainsScreenPoint(gridPanel, squares[i].transform.position))
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
}
