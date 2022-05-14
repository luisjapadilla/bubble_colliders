using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public GameObject RestartPanel;

    public Text timer;
    public float timeremainin;

    private bool haslost;

    private void Update()
    {
        if(haslost == false)
        {
            if(timeremainin > 0)
            {
                timer.text = timeremainin.ToString("F0");
                timeremainin -= Time.deltaTime;
            }
            else
            {

            }
        }
    }

    public void GameOver()
    {
        
        haslost = true;
        RestartPanel.SetActive(true);
    }
    public void GotogameScene()
    {
        SceneManager.LoadScene("game");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
