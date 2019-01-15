using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareScript : MonoBehaviour
{
    public int colorIndex;
    private Image img;

    public void SetImage()
    {
        img = gameObject.GetComponent<Image>();
    }

    public void SetColor(int _colorIndex)
    {
        colorIndex = _colorIndex;
        img.color = DataScript.instance.GetColor(_colorIndex);
    }

    public int GetColorIndex()
    {
        return colorIndex;
    }
}
