using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D PLayer_rb;

    public GameObject Enemy;
    public Rigidbody2D Enemy_rb;
    
    public float Hmove;
    public float Vmove;
    public float MoveSpeed = 20;

    void Start()
    {
        CheckInput();

        Player = GameObject.Find("Player");
        Enemy = GameObject.Find("Enemy");
    }

    void Update()
    {
        CheckInput();

        if (Vmove != 0)
        {
            PLayer_rb.velocity = new Vector2(0, Vmove * MoveSpeed * Time.deltaTime);
            Enemy_rb.velocity = new Vector2(0, -Vmove * MoveSpeed * Time.deltaTime);
        }
    }

    void CheckInput()
    {
        Vmove = Input.GetAxisRaw("Vertical");
        Hmove = Input.GetAxisRaw("Horizontal");
    }
}
