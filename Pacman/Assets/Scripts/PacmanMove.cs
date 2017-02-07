using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start ()
	{
	    dest = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FixedUpdate()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            dest = Valid(Vector2.up, dest);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dest = Valid(Vector2.right, dest);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dest = Valid(Vector2.down, dest);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dest = Valid(Vector2.left, dest);
        }

        Vector2 dir = dest - (Vector2) transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    Vector2 Valid(Vector2 dir, Vector2 dest)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir + Vector2.Scale(dir, new Vector2(0.1f, 0.1f)), pos);

        
        if (hit.collider.tag != "Wall")
        {
            if ((Vector2) transform.position == dest)
            {
                dest = (Vector2) transform.position + dir;
            }
        }

        return dest;
    }
}

