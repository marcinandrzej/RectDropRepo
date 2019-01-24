using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersScript : MonoBehaviour
{
    public Image powerImage;
    public Text powerTxt;
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

    public void LockPowers()
    {
        for (int i = 0; i < powerButtons.Length; i++)
        {
            powerButtons[i].enabled = false;
        }
    }

    private void UpdatePowers()
    {
        for (int i = 0; i < powerButtons.Length; i++)
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
        powerPoints = 0;
        maxPowerPoints = _maxPowerPoints;
        gameMan = _gameMan;
        UpdatePowers(); 
        powerButtons[0].onClick.AddListener(delegate { ClearColor();});
        powerButtons[1].onClick.AddListener(delegate { AddTime(1, 10.0f); });
        powerButtons[2].onClick.AddListener(delegate { Gravity(); });
    }

    public void ClearColor()
    {
        gameMan.EliminateColor(Random.Range(1, DataScript.instance.GetColorCount()));
        AddPP(-powerCost[0]);
    }

    public void AddTime(int index, float deltatime)
    {
        gameMan.timeScript.AddTime(deltatime);
        AddPP(-powerCost[1]);
    }

    public void Gravity()
    {
        gameMan.GravityFall();
        AddPP(-powerCost[2]);
    }

    public void AddPP(int deltaPP)
    {
        powerPoints = Mathf.Max(Mathf.Min(powerPoints + deltaPP, maxPowerPoints), 0);
        UpdatePP();
    }

    public void UpdatePP()
    {
        powerImage.fillAmount = (float)powerPoints / (float)maxPowerPoints;
        powerTxt.text = powerPoints.ToString() + "/" + maxPowerPoints.ToString();
        UpdatePowers();
    }
}
