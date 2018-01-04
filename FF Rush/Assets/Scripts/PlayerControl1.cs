using UnityEngine;
using System.Collections;

public class PlayerControl1 : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;

    private int _sgravity = 2;
    private int _egravity = 6;
    private int _forceX = 4;
    private int _forceY = 650 * 2;


    private bool _isGrounded = true;


    // Use this for initialization
    void Start()
    {
        this._transform = this.gameObject.GetComponent<Transform>();
        this._rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this._rigidbody2D.gravityScale = this._egravity;

        if (this._isGrounded)
        {
            if (((Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space)))
            {
                this.jump();
            }
        }

        this._rigidbody2D.velocity = new Vector2(this._forceX, this._rigidbody2D.velocity.y);
    }

    void jump()
    {
        this._rigidbody2D.AddForce(Vector2.up * this._forceY);
        this._rigidbody2D.gravityScale = this._sgravity;


        this._isGrounded = false;
    }

    void reset()
    {
        this._rigidbody2D.position = new Vector2(0, Mathf.Round(this._rigidbody2D.position.y));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            this._isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        // if (col.transform.tag == "Ground")
        // {
        //     this._isGrounded = false;
        // }
    }
}
