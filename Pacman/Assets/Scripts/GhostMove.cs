using UnityEngine;
using System.Collections;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 0.3f;

    private int _cur = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        if (transform.position != waypoints[this._cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[this._cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else
        {
            this._cur = (this._cur + 1) % waypoints.Length;
        }

        Vector2 dir = waypoints[this._cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "pacman")
        {
            Destroy(collision.gameObject);
        }
    }
}
