using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_position : MonoBehaviour
{
    private GameObject wall_left;
    private GameObject wall_right;
    private GameObject wall_up;
    private GameObject wall_down;
    void Start()
    {
        wall_left = GameObject.Find("left_wall");
        wall_right = GameObject.Find("right_wall");
        wall_up = GameObject.Find("up_wall");
        wall_down = GameObject.Find("down_wall");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "left_wall")
        {
            transform.position = new Vector2(wall_right.transform.position.x - 30, transform.position.y);
        }
        else if (collision.gameObject.name == "right_wall")
        {
            transform.position = new Vector2(wall_left.transform.position.x + 30, transform.position.y);
        }
        else if (collision.gameObject.name == "up_wall")
        {
            transform.position = new Vector2(transform.position.x, wall_down.transform.position.y + 30);
        }
        else if (collision.gameObject.name == "down_wall")
        {
            transform.position = new Vector2(transform.position.x, wall_up.transform.position.y - 30 );
        }
    }
}
