using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private const int GRID_DIMENSION = 9;
    private GameObject[,] cells;
    private UIScript uiScript;

    public Sprite emptyCellImage;
    public Transform gridPanel;

    // Use this for initialization
    void Start()
    {
        uiScript = gameObject.AddComponent<UIScript>();

        SetGrid();
    }

    private void SetGrid()
    {
        cells = uiScript.FillWithImages(gridPanel, GRID_DIMENSION, GRID_DIMENSION,
            emptyCellImage, DataScript.instance.GetColor(0), "CELL");
        foreach (GameObject cell in cells)
        {
            cell.tag = "CELL";
            cell.AddComponent<SquareScript>();
            cell.GetComponent<SquareScript>().SetImage();
            cell.GetComponent<SquareScript>().SetColor(0);
        }
    }

    public void CheckGrid(GameObject block)
    {
        Destroy(block);
    }
}
