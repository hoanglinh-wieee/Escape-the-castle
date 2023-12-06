using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float speed2;
    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
       m_rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity=Vector2.up * speed2;
    }
}
