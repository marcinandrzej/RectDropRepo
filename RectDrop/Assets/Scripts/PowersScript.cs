using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersScript : MonoBehaviour
{
    public Button[] powerButtons;
    public Sprite[] powerSprites;
    public int[] powerCost;
    public Sprite lockedSprite;

    private int maxPowerPoints;
    private int powerPoints;
    private GameManagerScript gameMan;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LockPowers()
    {
        for (int i = 0; i < powerCost.Length; i++)
        {
            if (powerCost[i] > powerPoints)
            {
                powerButtons[i].GetComponent<Image>().sprite = lockedSprite;
                powerButtons[i].enabled = false;
            }
            else
            {
                powerButtons[i].GetComponent<Image>().sprite = powerSprites[i];
                powerButtons[i].enabled = true;
            }
        }
    }

    public void SetUp(int _maxPowerPoints, GameManagerScript _gameMan)
    {
        powerPoints = 100;
        maxPowerPoints = _maxPowerPoints;
        gameMan = _gameMan;
        LockPowers(); 
        powerButtons[0].onClick.AddListener(delegate { ClearColor();});
        powerButtons[1].onClick.AddListener(delegate { AddTime(1, 10.0f); });
        powerButtons[2].onClick.AddListener(delegate { Gravity(); });
    }

    public void ClearColor()
    {
        gameMan.EliminateColor(Random.Range(1, DataScript.instance.GetColorCount()));
    }

    public void AddTime(int index, float deltatime)
    {
        gameMan.timeScript.AddTime(deltatime);
        powerPoints -= powerCost[index];
    }

    public void Gravity()
    {

    }
}
