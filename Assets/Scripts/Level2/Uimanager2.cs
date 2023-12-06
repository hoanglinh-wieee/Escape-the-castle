using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Uimanager2 : MonoBehaviour
{
    
    public string nameScene;
    public GameObject gameoverPanel;
   
    public void ShowGameoverPanel(bool isShow)
    {
        if(gameoverPanel)
            gameoverPanel.SetActive(isShow);
    }
    
    
    public void Replay(){
        SceneManager.LoadScene(nameScene);
    }
    
}
