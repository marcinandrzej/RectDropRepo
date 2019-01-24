using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public Button menuButton;
    public GameManagerScript gameMan;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnOffMenu()
    {
        menuPanel.SetActive(!menuPanel.active);
        gameMan.Stop = !gameMan.Stop;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BlockMenu()
    {
        menuButton.enabled = false;
    }
}
