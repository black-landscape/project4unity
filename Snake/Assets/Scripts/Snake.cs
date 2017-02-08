using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour
{
    private Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();

    private bool ate = false;

    public GameObject tailPrefab;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
    }

    void Move()
    {
        Vector2 v = transform.position;

        transform.Translate(dir);

        if (ate)
        {
            GameObject g = (GameObject) Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0,g.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            Destroy(collision.gameObject);
        }
    }
}
