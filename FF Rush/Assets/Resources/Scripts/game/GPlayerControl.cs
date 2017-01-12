using UnityEngine;
using System.Collections;

public class GPlayerControl : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;

    private float _oy = 0.0f;
    private float _cy;
    private float _moveGapY = 1.2f;
    private float _sgravity = 2.0f;
    private float _egravity = 6.0f;
    private float _forceY = 5000.0f;

    private bool _isJumping = false;

	// Use this for initialization
	void Start ()
	{
        this._transform = this.gameObject.GetComponent<Transform>();
	    this._rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        this._rigidbody2D.AddForce(Vector2.right * 2000);

        
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //this._rigidbody2D.MovePosition(this._rigidbody2D.position + Vector2.up);

            this._isJumping = true;
            this._rigidbody2D.AddForce(Vector2.up * this._forceY);
            this._rigidbody2D.gravityScale = this._sgravity;
        }

        if (this._isJumping)
        {
            this._cy = this._transform.position.y;
            if (0 != this._oy)
            {
                Debug.Log("this._oy------" + this._oy);
                Debug.Log("this._cy - this._oy------" + (this._cy - this._oy));
                if (this._cy - this._oy >= this._moveGapY)
                {
                    this._isJumping = false;
                    this._oy = 0;
                    this._rigidbody2D.gravityScale = this._egravity;
                }
                else
                {
                    //this._rigidbody2D.MovePosition(this._rigidbody2D.position + Vector2.up * this._moveY);

                }
            }
            else
            {
                Debug.Log("this._oy------null");
                //this._rigidbody2D.MovePosition(this._rigidbody2D.position + Vector2.up * this._moveY);
                this._oy = this._transform.position.y;
            }
        }
    }

    void FixedUpdate()
    {
        //this._rigidbody2D.AddForce(Vector2.right * 10);
        //this._rigidbody2D.MovePosition(this._rigidbody2D.position + Vector2.right);
    }
}
