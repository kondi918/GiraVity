using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PullIntoTheHole : MonoBehaviour
{
    private float distance;
    private GameObject blackHole;
    private GameObject player;
    private Vector2 direct;
    private float min_distance = 7f;
    private int easingIDx = -1;
    private int easingIDy = -1;
    public static bool pulling = true;
    // Start is called before the first frame update
    void Start()
    {
        blackHole = GameObject.Find("black_hole_official");
        player = GameObject.Find("giraffe");
        StartCoroutine(checkColission());
    }
    IEnumerator checkColission()
    {
        while (true)
        {
            check_collision();
            yield return null;
        }

    }
    private void check_collision()
    {
        min_distance += 0.001f;
        distance = Vector3.Distance(blackHole.transform.position, player.transform.position);
        if (distance < min_distance)
        {
            //player.transform.position = blackHole.transform.position + (player.transform.position - blackHole.transform.position) * 0.97f;
            if (!LeanTween.isTweening(easingIDx))
                easingIDx = LeanTween.value(player.transform.position.x, blackHole.transform.position.x + (player.transform.position.x - blackHole.transform.position.x) * 0.85f, 0.1f).setOnUpdate(IncreaseValue).uniqueId;
            if (!LeanTween.isTweening(easingIDy))
                easingIDy = LeanTween.value(player.transform.position.y, blackHole.transform.position.y + (player.transform.position.y - blackHole.transform.position.y) * 0.85f, 0.1f).setOnUpdate(IncreaseValueY).uniqueId;

        }

    }
    // Update is called once per frame
    private void IncreaseValue(float valueX)
    {
        if (pulling)
        {
            player.transform.position = new Vector3(valueX, player.transform.position.y);
        }
    }

    private void IncreaseValueY(float valueY)
    {
        if (pulling)
        {
            player.transform.position = new Vector3(player.transform.position.x, valueY);
        }
    }
}


