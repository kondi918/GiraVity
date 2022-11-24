using UnityEngine;
using System.Collections.Generic;

public class clonning_enemies : MonoBehaviour
{
    public GameObject enemy_pattern;
    GameObject new_enemy;
    private Transform enemyContainer;
    public static List<GameObject> enemies_list = new();
    float seconds = 0;
    public static int nr_of_enemies = 0;

    private void Awake()
    {
        enemyContainer = transform.Find("enemyContainer");
    }

    private void adding_enemy()
    {
        new_enemy = Instantiate(enemy_pattern, new Vector3(Random.Range(-99, 100), Random.Range(-90, 91), enemy_pattern.transform.position.z), Quaternion.identity, enemyContainer);
        new_enemy.SetActive(true);
        enemies_list.Add(new_enemy);
        nr_of_enemies++;
    }
    void Update()
    {
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        if (nr_of_enemies < 25 && seconds >= 1.5f)
        {
            adding_enemy();
            seconds = 0;
        }
        if (seconds < 3)
        {
            seconds += Time.deltaTime;
        }
    }
}
