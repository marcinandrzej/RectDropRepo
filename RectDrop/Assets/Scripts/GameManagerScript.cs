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

        cells = uiScript.FillWithImages(gridPanel, GRID_DIMENSION, GRID_DIMENSION,
            emptyCellImage, new Color32(50, 50, 50, 255), "CELL");
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
