using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    float spawTime = 1f;
    float nextspawn = 0f;
    public GameObject projectile;
    public Transform shootingPoint;
    public GameObject Player;
    Rigidbody2D PlayerRB;
    /// <summary>
    public int maxHealth = 2;
    //mau hien tai
    private int currentHealth;
    //
    private float Attack1time;
    //trang thai
    public Vector3[] taget;
    //
    private float Part = 1;
    private bool Bosslife = true;
    //
    //Attack

    public float attackRate;
    public int attackDamage;
    private bool canAttack;
    //thiet lam animation tang cong2
    
    
    
    // 
    public float speedGoAttack;
    private bool isfacingRight = false;
    private Animator anim;
    private Rigidbody2D rb;
    private Rigidbody2D rbplayer;
    private float left_right;
    private bool thunLR;
    //AImoverest
    public float speed = 5f;
    public float moveTime = 4f;
    public float restTime = 4f;
    private bool ChangeStatus = true;
    private bool ChangeStatusLR = true;
    private float nextChangeStatusTime = 0f;
    public Transform[] Bossposition;
    UIManager m_ui;
    /// </summary>
    void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        nextspawn+=Time.deltaTime;
        if(nextspawn>=spawTime){
            Shoot();
            nextspawn=0;
        }
        if (Bosslife)
        {   
            Part1Boss();
        }
    }
    private void Part1Boss()
    {
        //Boss di chuyen qua lai
        AimoveLeft_right();
    }
    public void AimoveLeft_right()
    {
        if (Time.time >= nextChangeStatusTime)
        {
            Debug.Log(Time.time);
            Debug.Log(nextChangeStatusTime);
            if (ChangeStatus)
            {
                if (ChangeStatusLR)
                {
                    left_right = -1;
                    ChangeStatusLR = false;
                }
                else
                {
                    left_right = 1;
                    ChangeStatusLR = true;
                }
                ChangeStatus = false;
                nextChangeStatusTime = Time.time + moveTime;
            }
            else
            {
                left_right = 0;
                ChangeStatus = true;
                nextChangeStatusTime = Time.time + restTime;
            }
        }
        rb.velocity = new Vector2(left_right * speed, rb.velocity.y);
        flip();
    }
    void flip()
    {
        if (isfacingRight && left_right < 0 || !isfacingRight && left_right > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x * -1;
            transform.localScale = kich_thuoc;
        }
    }
    void Shoot()
    {
        if(projectile && shootingPoint)
        {

            Vector3 positionPoint = new Vector3(PlayerRB.position.x, shootingPoint.position.y , shootingPoint.position.z);
            GameObject Projectile = Instantiate(projectile, positionPoint, Quaternion.identity) as GameObject;
            Projectile.GetComponent<Swordm3>().SettagetPlayer(false);
        }
    }
    public void TakeDamePlayer(){
        Debug.Log(currentHealth);
        currentHealth--;
        if(currentHealth == 0){
            BossDie();
        }
    }
    void BossDie(){
        m_ui.ShowWinGame(true);
        Player.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}
