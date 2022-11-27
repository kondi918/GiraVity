using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BlackHoleMovement : MonoBehaviour
{
    private Vector3 velocity;
    private Rigidbody2D rb;
    private float x_move;
    private float y_move;
    private Vector2 size;
    // Start is called before the first frame update
    void Start()
    {
        while (Vector2.Distance(GameObject.Find("giraffe").transform.position, transform.position) < 40)
        {
            transform.position = new Vector2(Random.Range(-99, 100), Random.Range(-90, 91));
        }
        x_move = Random.Range(150, 250);
        y_move = Random.Range(150, 250);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(30 * Time.deltaTime * x_move, 30 * Time.deltaTime * y_move));
    }
    private void scale()
    {
        size = transform.localScale;
        size.x += 0.0005f;
        size.y += 0.0005f;
        transform.localScale = size;
    }
    void FixedUpdate()
    {
        velocity = rb.velocity;
        scale();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = velocity.magnitude;
        var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
