using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    public static DataScript instance;

    private Color32[] colors;

    void Awake()
    {
        if (instance == null)
            instance = this;
        SetColors();
    }

    private void SetColors()
    {
        colors = new Color32[6];
        colors[0] = new Color32(50, 50, 50, 255);
        colors[1] = new Color32(0, 255, 255, 255);
        colors[2] = new Color32(255, 0, 255, 255);
        colors[3] = new Color32(0, 255, 0, 255);
        colors[4] = new Color32(255, 255, 0, 255);
        colors[5] = new Color32(255, 0, 0, 255);
    }

    public Color32 GetColor(int index)
    {
        return colors[index];
    }

    public int GetColorCount()
    {
        return colors.Length;
    }
}
