using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordm3 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float timeToDestroy;
    public bool setupdow = true;
    private bool Updown = true;
    private Vector2 velocityPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeToDestroy);
        rb.velocity = Vector2.up * speed;
        rb.rotation = 26f;
    }
    // Update is called once per frame
    public void SettagetPlayer(bool updown){
        if (updown)
        {
            rb.velocity = Vector2.up*speed;
        }
        else
        {
            rb.velocity = Vector2.down*speed;
            Updown = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.GetComponent<Boss>() && Updown){
            col.GetComponent<Boss>().TakeDamePlayer();
        }
        if(col.GetComponent<Player>() && !Updown){
            col.GetComponent<Player>().TakeDameBoss();
        }
    }
}
