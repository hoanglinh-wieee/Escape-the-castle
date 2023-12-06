using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float moveSpeed;
    float xDirection;
    public GameObject projectile;
    public GameObject Boss;
    public Transform shootingPoint;
    [SerializeField]
    public SceneInfo sceneInfo;
    UIManager m_ui;
    int CountShoot;
    // Start is called before the first frame update
    void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        CountShoot = sceneInfo.Score;
    }

    // Update is called once per frame
    void Update()
    {
        //moveSpeed=10;
        xDirection = Input.GetAxisRaw("Horizontal");
        float moveStep = moveSpeed * xDirection * Time.deltaTime;
        
        if((transform.position.x <=-8&& xDirection<0)||(transform.position.x>=8&&xDirection>0))
            return;

        transform.position = transform.position + new Vector3(moveStep,0,0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(CountShoot > 0){
                Shoot();
                CountShoot--;
            }
        }
    }
    public void Shoot()
    {
        if(projectile&&shootingPoint)
        {
            Instantiate(projectile, shootingPoint.position,Quaternion.identity);
        }
    }
    public void TakeDameBoss(){
        Boss.GetComponent<Collider2D>().enabled = false;
        m_ui.ShowGameoverPanel(true);
    }
}