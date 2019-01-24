using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordScript : MonoBehaviour
{
    public Text recordTxt;

    private int record;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadRecord()
    {
        if (PlayerPrefs.HasKey("RectDropRecord"))
        {
            record = PlayerPrefs.GetInt("RectDropRecord");
        }
        else
        {
            record = 0;
        }
        recordTxt.text = "HIGHSCORE:\n" + record.ToString();
    }

    public bool IsRecord(int score)
    {
        if (score > record)
            return true;
        return false;
    }

    public void SaveRecord(int score)
    {
        record = score;
        PlayerPrefs.SetInt("RectDropRecord", score);
        recordTxt.text = "HIGHSCORE:\n" + record.ToString();
    }
}
