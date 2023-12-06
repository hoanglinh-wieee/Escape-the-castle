using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LoadNextLevel2 : MonoBehaviour
{
    public float delaySecond ;
    public int Score;
    public string nameScene ;
    // Start is called before the first frame update
    [SerializeField]
    public SceneInfo sceneInfo;
    void Start(){
        Score = sceneInfo.Score;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            ModeSelect();
        }
    }
    public void ModeSelect()
    {
        sceneInfo.Score = Score;
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene(nameScene);
    }
    // Update is called once per frame
}
