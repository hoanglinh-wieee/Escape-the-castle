using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public string nameScene;
    public GameObject gameoverPanel;
    public GameObject gamewinPanel;
    public void SetScoreText(string txt)
    {
        if(scoreText)
            scoreText.text = txt;
    }
    public void ShowGameoverPanel(bool isShow)
    {
        if(gameoverPanel)
            gameoverPanel.SetActive(isShow);
    }
    public void ShowWinGame(bool isShow)
    {
        if(gamewinPanel)
            gamewinPanel.SetActive(isShow);
    }
    
    public void Replay(){
        SceneManager.LoadScene(nameScene);
    }
}