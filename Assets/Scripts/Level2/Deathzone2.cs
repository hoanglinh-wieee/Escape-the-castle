using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone2 : MonoBehaviour
{
    // Start is called before the first frame update
    Uimanager2 m_ui;
    Player2 Player;
    void Awake(){
        m_ui = FindObjectOfType<Uimanager2>();
        Player = FindObjectOfType<Player2>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            m_ui.ShowGameoverPanel(true);
            Destroy(Player.gameObject);
        }
    }
}
