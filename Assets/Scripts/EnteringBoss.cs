using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringBoss : MonoBehaviour
{
    private GameObject boss;
    public GameObject boss_pattern;
    private Collider2D black_hole_collider;
    private Collider2D main_char_collider;
    void Start()
    {
        black_hole_collider = GameObject.Find("black_hole_official").GetComponent<Collider2D>();
        main_char_collider = GameObject.Find("giraffe").GetComponent<Collider2D>();
    }
    void FixedUpdate()
    {
        if (black_hole_collider.IsTouching(main_char_collider))
        {
            for(int i=0; i<clonning_enemies.enemies_list.Count; i++)
            {
                Object.Destroy(clonning_enemies.enemies_list[i]);
            }
            GameObject.Find("black_hole_official").transform.localScale = new Vector3(1, 1, 0);
            clonning_enemies.nr_of_enemies = 0;
            PullIntoTheHole.pulling = false;
            Debug.Log("dziala");
            GameObject.Find("giraffe").transform.position = new Vector3(480f, 0f, 0f);
            Debug.Log(GameObject.Find("giraffe").transform.position);
            boss = Instantiate(boss_pattern, new Vector3(boss_pattern.transform.position.x, boss_pattern.transform.position.y, boss_pattern.transform.position.z), Quaternion.identity, transform);
            boss.SetActive(true);
            GameObject.Find("MAP_OBJECTS").SetActive(false);
        }
    }
}
