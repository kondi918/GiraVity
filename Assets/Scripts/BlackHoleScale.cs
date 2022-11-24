using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScale : MonoBehaviour
{
    private GameObject blackHole;
    private Vector2 size;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        blackHole = GameObject.Find("black_hole_official");
    }
    private void scale()
    {
        size = blackHole.transform.localScale;
        size.x += 0.0005f;
        size.y += 0.0005f;
        blackHole.transform.localScale = size;
    }
    private void bounce()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        scale();
    }
}
