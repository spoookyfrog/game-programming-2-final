using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class movingplatform : MonoBehaviour
{
    public float speed;
    public int startingpoint;
    public Transform[] points;
    private int i;
    void Start()
    {
        transform.position = points[startingpoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position) <0.02f)
        {
            i++;

                if (i == points.Length)
                {
                    i = 0;
                }
            
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) //so player can move with the platform by becoming a child of the object
    {
        if(collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }

    }
    void OnCollisionStay2D(Collision2D collision) // so player move while still on platform
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision) //so player can get off of the platfrom and stop being a child of the object
    {
        if (transform.position.y != 0) 
        {
            collision.transform.SetParent(null);
        }
    }
}