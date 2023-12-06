using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Try()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
    public void Info()
    {
        SceneManager.LoadScene(3);
    }
}
