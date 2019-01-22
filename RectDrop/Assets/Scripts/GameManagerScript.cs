using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private const int MAX_PP = 100;
    private const float MAX_TIME = 60.0f;
    private const float TIME_PRE_SQUARE = 1.0f;
    private const int GRID_DIMENSION = 9;
    private GameObject[,] cells;
    private UIScript uiScript;
    private Vector2[] startingPoints;
    private float squareW;
    private float squareH;
    private List<GameObject> cellsTocheckList;
    private List<GameObject> cellsToResetList;
    private List<GameObject> blocksInGame;

    public Sprite emptyCellImage;
    public Transform gridPanel;
    public GameObject blocksPanel;
    public TimeScript timeScript;
    public ScoreScript scoreScript;
    public PowersScript powersScript;

    // Use this for initialization
    void Start()
    {
        uiScript = gameObject.AddComponent<UIScript>();

        SetGrid();
        SetBlocks();
        scoreScript.SetUp();
        powersScript.SetUp(MAX_PP, this);
        timeScript.StartClock(MAX_TIME);
    }

    void Update()
    {
        if (!timeScript.UpdateClock(Time.deltaTime))
            End();
    }

    private void SetGrid()
    {
        cellsTocheckList = new List<GameObject>();
        cells = uiScript.FillWithImages(gridPanel, GRID_DIMENSION, GRID_DIMENSION,
            emptyCellImage, DataScript.instance.GetColor(0), "CELL");
        for (int _x = 0; _x < cells.GetLength(0); _x++)
        {
            for (int _y = 0; _y < cells.GetLength(1); _y++)
            {
                cells[_x, _y].tag = "CELL";
                cells[_x, _y].AddComponent<SquareScript>();
                cells[_x, _y].GetComponent<SquareScript>().SetImage();
                cells[_x, _y].GetComponent<SquareScript>().SetColor(0);
                cells[_x, _y].GetComponent<SquareScript>().X = _x;
                cells[_x, _y].GetComponent<SquareScript>().Y = _y;
            }
        }

    }

    private void SetBlocks()
    {
        blocksInGame = new List<GameObject>();
        squareW = Mathf.Abs(gridPanel.gameObject.GetComponent<RectTransform>().sizeDelta.x) / (float)GRID_DIMENSION;
        squareH = Mathf.Abs(gridPanel.gameObject.GetComponent<RectTransform>().sizeDelta.y) / (float)GRID_DIMENSION;

        startingPoints = new Vector2[3];
        startingPoints[0] = new Vector2(-200, 0);
        startingPoints[1] = new Vector2(0, 0);
        startingPoints[2] = new Vector2(200, 0);

        for (int i = 0; i < startingPoints.Length; i++)
        {
            blocksInGame.Add(CreateBlock("Block" + (i + 1).ToString(), i));
        }
    }

    private GameObject CreateBlock(string name, int posIndex)
    {
        GameObject block = uiScript.CreateImage(name, blocksPanel.transform, new Vector2(2 * squareW, 2* squareH), new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), startingPoints[posIndex], new Vector3(0, 0, 0),
            emptyCellImage, Image.Type.Sliced, new Color32(0,0,0,0));
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
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 1:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f),
           new Vector3(0, 0, 0), emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 2:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 3:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 4:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 5:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 6:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 7:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 8:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            case 9:
                square = uiScript.CreateImage("square1", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square2", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, -squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square3", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(-squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                square = uiScript.CreateImage("square4", block.transform, new Vector2(squareW, squareH), new Vector2(0.5f, 0.5f),
           new Vector2(0.5f, 0.5f), new Vector3(1, 1, 1), new Vector2(0.5f, 0.5f), new Vector2(squareW / 2.0f, squareH / 2.0f), new Vector3(0, 0, 0),
           emptyCellImage, Image.Type.Sliced, DataScript.instance.GetColor(0));
                square.AddComponent<SquareScript>();
                square.GetComponent<SquareScript>().SetImage();
                square.GetComponent<SquareScript>().SetColor(Random.Range(1, DataScript.instance.GetColorCount()));
                block.GetComponent<BlockScript>().AddSquare(square);
                break;
            default:
                break;
        }
    }

    public void AddToCheckList(GameObject _cell)
    {
        cellsTocheckList.Add(_cell);
    }

    public void EliminateColor(int colorIndex)
    {
        for (int _x = 0; _x < cells.GetLength(0); _x++)
        {
            for (int _y = 0; _y < cells.GetLength(1); _y++)
            {
                if(cells[_x, _y].GetComponent<SquareScript>().GetColorIndex() == colorIndex)
                    cells[_x, _y].GetComponent<SquareScript>().SetColor(0);
            }
        }
    }

    public void CheckGrid(GameObject block, int posIndex)
    {
        blocksInGame.Remove(block);
        Destroy(block);
        blocksInGame.Add(CreateBlock("Block" + (posIndex + 1).ToString(), posIndex));

        cellsToResetList = new List<GameObject>();

        for (int i = 0; i < cellsTocheckList.Count; i++)
        {
            List<GameObject> horizontalList = new List<GameObject>();
            List<GameObject> VerticalList = new List<GameObject>();

            CheckHorizontalPlus(cellsTocheckList[i].GetComponent<SquareScript>().GetColorIndex(), cellsTocheckList[i].GetComponent<SquareScript>().X,
                cellsTocheckList[i].GetComponent<SquareScript>().Y, horizontalList);
            CheckHorizontalMinus(cellsTocheckList[i].GetComponent<SquareScript>().GetColorIndex(), cellsTocheckList[i].GetComponent<SquareScript>().X,
                cellsTocheckList[i].GetComponent<SquareScript>().Y, horizontalList);
            CheckVerticalMinus(cellsTocheckList[i].GetComponent<SquareScript>().GetColorIndex(), cellsTocheckList[i].GetComponent<SquareScript>().X,
                cellsTocheckList[i].GetComponent<SquareScript>().Y, VerticalList);
            CheckVerticalPlus(cellsTocheckList[i].GetComponent<SquareScript>().GetColorIndex(), cellsTocheckList[i].GetComponent<SquareScript>().X,
                cellsTocheckList[i].GetComponent<SquareScript>().Y, VerticalList);

            if (horizontalList.Count >= 3)
            {
                for (int j = 0; j < horizontalList.Count; j++)
                {
                    if(!cellsToResetList.Contains(horizontalList[j]))
                        cellsToResetList.Add(horizontalList[j]);
                }
            }

            if (VerticalList.Count >= 3)
            {
                for (int g = 0; g < VerticalList.Count; g++)
                {
                    if (!cellsToResetList.Contains(VerticalList[g]))
                        cellsToResetList.Add(VerticalList[g]);
                }
            }
        }

        if (cellsToResetList.Count > 0)
        {
            foreach (GameObject _cell in cellsToResetList)
            {
                _cell.GetComponent<SquareScript>().SetColor(0);
            }
            timeScript.AddTime((float)cellsToResetList.Count * TIME_PRE_SQUARE);
            scoreScript.AddScore(cellsToResetList.Count);
            powersScript.AddPP(cellsToResetList.Count);
            cellsTocheckList = new List<GameObject>();
        }
    }

    private void CheckHorizontalPlus(int _colorIndex, int _x, int _y, List<GameObject> checkList)
    {
        if (_x >= 0 && _x < GRID_DIMENSION)
        {
            if (cells[_x, _y].GetComponent<SquareScript>().GetColorIndex() == _colorIndex)
            {
                if(!checkList.Contains(cells[_x, _y]))
                    checkList.Add(cells[_x, _y]);
                CheckHorizontalPlus(_colorIndex, _x + 1, _y, checkList);
            }
        }
    }

    private void CheckHorizontalMinus(int _colorIndex, int _x, int _y, List<GameObject> checkList)
    {
        if (_x >= 0 && _x < GRID_DIMENSION)
        {
            if (cells[_x, _y].GetComponent<SquareScript>().GetColorIndex() == _colorIndex)
            {
                if (!checkList.Contains(cells[_x, _y]))
                    checkList.Add(cells[_x, _y]);
                CheckHorizontalMinus(_colorIndex, _x - 1, _y, checkList);
            }
        }
    }

    private void CheckVerticalMinus(int _colorIndex, int _x, int _y, List<GameObject> checkList)
    {
        if (_y >= 0 && _y < GRID_DIMENSION)
        {
            if (cells[_x, _y].GetComponent<SquareScript>().GetColorIndex() == _colorIndex)
            {
                if (!checkList.Contains(cells[_x, _y]))
                    checkList.Add(cells[_x, _y]);
                CheckVerticalMinus(_colorIndex, _x, _y -1, checkList);
            }
        }
    }

    private void CheckVerticalPlus(int _colorIndex, int _x, int _y, List<GameObject> checkList)
    {
        if (_y >= 0 && _y < GRID_DIMENSION)
        {
            if (cells[_x, _y].GetComponent<SquareScript>().GetColorIndex() == _colorIndex)
            {
                if (!checkList.Contains(cells[_x, _y]))
                    checkList.Add(cells[_x, _y]);
                CheckVerticalPlus(_colorIndex, _x, _y + 1, checkList);
            }
        }
    }

    private void End()
    {
        foreach (GameObject block in blocksInGame)
        {
            Destroy(block);
        }
        powersScript.LockPowers();
    }

    public void GravityFall()
    {
        for (int x = 0; x < GRID_DIMENSION; x++)
        {
            for (int y = (GRID_DIMENSION - 1); y > 0; y--)
            {
                while (cells[x, y].GetComponent<SquareScript>().GetColorIndex() == 0 && CanFall(x, y))
                {
                    Fall(x, y);
                }
            }
        }
    }

    private bool CanFall(int x, int y)
    {
        for (int i = 0; i < y; i++)
        {
            if (cells[x, i].GetComponent<SquareScript>().GetColorIndex() != 0)
                return true;
        }
        return false;
    }

    private void Fall(int x, int y)
    {
        for (int i = y; i > 0; i--)
        {
            cells[x, i].GetComponent<SquareScript>().SetColor(cells[x, i - 1].GetComponent<SquareScript>().GetColorIndex());
        }
        cells[x, 0].GetComponent<SquareScript>().SetColor(0);
    }
}
