using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ballRb;
    
    public Rigidbody2D rb_player;
    public Rigidbody2D rb_enemy;

    public bool OnWallDown = false;
    public bool OnWallUp = false;

    public float moveSpeed = 3;
    float x = 0;
    void Start()
    {
        ballRb = gameObject.GetComponent<Rigidbody2D>();
        ballRb.velocity = new Vector2(1, 0) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        switch(collision.gameObject.tag)
        {
            case "WallRight": x = 1; break;
            case "Player": x = 1; collision.rigidbody.angularVelocity = 0; collision.rigidbody.velocity = Vector3.zero; break;

            case "enemy":  x = -1; collision.rigidbody.isKinematic = true; break;
            case "WallLeft": x = -1; break;

            case "WallUp": OnWallUp = true; x = 1;  break;
            case "WallDown": OnWallDown = true; x = -1; break;
        }
        MoveBall(collision, x);

        //  ballRb.velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().position.x, );
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        { 
        collision.rigidbody.isKinematic = false;
        }
    }

    private void MoveBall(Collision2D collision, float x)
    {
        float a = transform.position.y - collision.gameObject.transform.position.y;
        float b = collision.collider.bounds.size.y;
        float y = a / b;
        /* 
         switch(OnWall)
          {
            case true:
            y = transform.position.y;
            ballRb.velocity = new Vector2(x * moveSpeed, y);
            OnWallDown = false;
            OnWallUp = false; 
            break;

            case false:  ballRb.velocity = new Vector2(x, y) * moveSpeed; 
            breaks;
          }
         */

        if (OnWallDown)
        {
            //  y = -transform.position.y;
            y = transform.position.y;
            ballRb.velocity = new Vector2(x * moveSpeed, y);
            OnWallDown = false;
            OnWallUp = false;
        }
        else if(OnWallUp)
        {
            //  y -= transform.position.y;
            y = transform.position.y;
            ballRb.velocity = new Vector2(x * moveSpeed, y );
            OnWallDown = false;
            OnWallUp = false;
        } 
        else
        { 
            ballRb.velocity = new Vector2(x, y) * moveSpeed;
        }

    }
}
