using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{

    GameObject[] enemies = new GameObject[10];
    public float spawnTime = 60f;
    public GameObject asteroid;
    private GameObject new_asteroid;
    private float asteroid_rain_timer;
    private float time_between_asteroid;

    private void AsteroidRain(){
        if (time_between_asteroid >= 0.5f)
        {
            Vector3 main_character_position = GameObject.Find("giraffe").transform.position;
            time_between_asteroid = 0;
            new_asteroid = GameObject.Instantiate(asteroid, new Vector3(Random.Range(main_character_position.x - 15, main_character_position.x + 15), main_character_position.y + 20, 0), Quaternion.identity);
            new_asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
            new_asteroid.SetActive(true);
            Destroy(new_asteroid, 5f);

        }
    }
    private void timers_checking()
    {
        if (asteroid_rain_timer < 30f)
        {
            asteroid_rain_timer += Time.deltaTime;
        }
        else if (asteroid_rain_timer >= 30f && asteroid_rain_timer < 40f)
        {
            asteroid_rain_timer += Time.deltaTime;
            time_between_asteroid += Time.deltaTime;
            AsteroidRain();
        }
        else
        {
            asteroid_rain_timer = 0;
        }
    }
    void Update()
    {
        timers_checking();
    }
}
