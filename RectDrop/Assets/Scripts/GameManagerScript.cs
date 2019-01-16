using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private const int GRID_DIMENSION = 9;
    private GameObject[,] cells;
    private UIScript uiScript;
    private Vector2[] startingPoints;
    private float squareW;
    private float squareH;
    private List<GameObject> blocksList;

    public Sprite emptyCellImage;
    public Transform gridPanel;
    public GameObject blocksPanel;

    // Use this for initialization
    void Start()
    {
        uiScript = gameObject.AddComponent<UIScript>();

        SetGrid();
        SetBlocks();
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

    private void SetBlocks()
    {
        blocksList = new List<GameObject>();
        squareW = Mathf.Abs(gridPanel.gameObject.GetComponent<RectTransform>().sizeDelta.x) / (float)GRID_DIMENSION;
        squareH = Mathf.Abs(gridPanel.gameObject.GetComponent<RectTransform>().sizeDelta.y) / (float)GRID_DIMENSION;

        startingPoints = new Vector2[3];
        startingPoints[0] = new Vector2(-200, 0);
        startingPoints[1] = new Vector2(0, 0);
        startingPoints[2] = new Vector2(200, 0);

        for (int i = 0; i < startingPoints.Length; i++)
        {
            blocksList.Add(CreateBlock("Block" + (i + 1).ToString(), i));
        }
    }

    private GameObject CreateBlock(string name, int posIndex)
    {
        GameObject block = uiScript.CreateBlock(name, blocksPanel.transform, new Vector2(2 * squareW, 2* squareH), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), startingPoints[posIndex], new Vector3(0, 0, 0));
        block.AddComponent<BlockScript>();
        block.GetComponent<BlockScript>().SetBlock(this, gridPanel.GetComponent<RectTransform>(), posIndex);
        FillWithSquares(block, Random.Range(0,10));
        return block;
    }

    private void FillWithSquares(GameObject block, int shapeOption)
    {
        switch (shapeOption)
        {
            case 0:
                GameObject square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f),
            new Vector3(0, 0, 0), emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 1:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f),
           new Vector3(0, 0, 0), emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 2:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 3:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 4:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 5:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 6:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 7:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 8:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 9:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square4", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount() - 1));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            default:
                break;
        }
    }

    public void CheckGrid(GameObject block, int posIndex)
    {
        Destroy(block);
        CreateBlock("Block" + (posIndex + 1).ToString(), posIndex);
    }
}
