using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;

    private float _oy = 0.0f;
    private float _cy;
    private float _moveGapY = 1.2f;
    private float _sgravity = 2.0f;
    private float _egravity = 6.0f;
    private float _forceX = 4.0f;
    private float _forceY = 500.0f;

    private bool _isJumping = false;

    private Vector3 _velocity;

    private int _jumpCounter;

    private int _maxJumpCount = 2;


	// Use this for initialization
	void Start ()
	{
        this._transform = this.gameObject.GetComponent<Transform>();
	    this._rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this._jumpCounter < this._maxJumpCount)
        {
            this._rigidbody2D.velocity = new Vector2(this._rigidbody2D.velocity.x, 0.0F);
            this._rigidbody2D.AddForce(Vector2.up * this._forceY);
            this._rigidbody2D.gravityScale = this._sgravity;
            this._jumpCounter ++;
            this._isJumping = true;
        }

        // if(!this._isJumping)
        // {
        //     this._rigidbody2D.gravityScale = this._egravity;
        // }


        if (this._isJumping)
        {
            this._cy = this._transform.position.y;
            if (0 != this._oy)
            {
                if (this._cy - this._oy >= this._moveGapY*this._jumpCounter)
                {
                    // this._isJumping = false;
                    this._rigidbody2D.gravityScale = this._egravity;
                }
                else
                {

                }
            }
            else
            {
                this._oy = this._transform.position.y;
            }
        }

        this._velocity = new Vector2(this._forceX, this._rigidbody2D.velocity.y);
    }

    void FixedUpdate()
    {
        //this._rigidbody2D.AddForce(Vector2.right * 10);
        //this._rigidbody2D.MovePosition(this._rigidbody2D.position + Vector2.right);

        this._rigidbody2D.velocity = this._velocity;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        this._jumpCounter = 0;
        this._isJumping = false;
        this._oy = 0;
    }
}
