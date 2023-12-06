using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LoadNextLevel : MonoBehaviour
{
    public float delaySecond ;
    public string nameScene ;
    public GameObject GameController;

    [SerializeField]
    public SceneInfo sceneInfo;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            ModeSelect();
        }
    }
    public void ModeSelect()
    {
        sceneInfo.Score = GameController.GetComponent<GameController>().GetScore();
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {   
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene(nameScene);
    }
    // Update is called once per frame
}
