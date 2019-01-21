using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreTxt;

    private int score;

    public void SetUp()
    {
        score = 0;
        scoreTxt.text = "Score:\n0";
    }

    private void UpdateView()
    {
        scoreTxt.text = "Score:\n" + score.ToString();
    }

    public void AddScore(int squaresCount)
    {
        int deltaScore = 0;
        for (int i = 1; i <= squaresCount; i++)
        {
            deltaScore += ((i * 10) - 5);
        }

        score += deltaScore;
        UpdateView();
    }

    public int GetScore()
    {
        return score;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
