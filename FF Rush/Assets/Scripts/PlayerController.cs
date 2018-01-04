using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D jugador;
    public float velocidad, salto, bigJump;
    bool isGrounded, flappy;
    bool win;


    void Start()
    {
        jugador = GetComponent<Rigidbody2D>();
        flappy = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        { SceneManager.LoadScene("menu"); }

        if (!win)
        {
            if (isGrounded)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
                {
                    jump();
                }
            }
            else if (flappy)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
                {
                    flappyJump();
                }

            }
            transform.position =
            new Vector3(transform.position.x + velocidad, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            isGrounded = true;
        }
        else if (col.transform.tag == "Groundx2")
        {
            megaJump();
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "flappy")
        {
            if (flappy)
            {
                flappy = false;
            }
            else
            {
                isGrounded = true;
                flappy = true;
            }

        }
        else if (col.tag == "Meta")
        {
            win = true;
            SceneManager.LoadScene("win");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Groundx2")
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Groundx2")
        {
            isGrounded = false;
        }
    }

    void jump()
    {
        jugador.velocity = new Vector3(0f, salto, 0f);
        isGrounded = false;
    }
    void flappyJump()
    {
        jugador.velocity = new Vector3(0f, salto, 0f);
    }
    void megaJump()
    {
        jugador.velocity = new Vector3(0f, bigJump, 0f);
        isGrounded = false;
    }

}
