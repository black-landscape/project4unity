using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

	// Use this for initialization
	void Start ()
	{
	    this._rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update () {
	
	}

    void FixedUpdate()
    {
        this._rigidbody2D.AddForce(Vector2.right * 10);

    }
}
