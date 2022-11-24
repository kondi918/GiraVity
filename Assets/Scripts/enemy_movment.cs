using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movment : MonoBehaviour
{
    public GameObject bullet;

    public GameObject heart;
    private GameObject projectile_enemy;
    GameObject enemy_pattern;
    private float bullet_time = 0;
    private float random_generator_timer = 0;
    GameObject main_character;
    private Vector3 direction;

    void Start()
    {
        main_character = GameObject.Find("giraffe");
        enemy_pattern = GameObject.Find("giraffe_enemy");
    }
    private Vector3 get_main_character_position()
    {
        return main_character.transform.position;
    }
    private float distance_to_character()
    {
        //ponizej obliczana jest odleglosc z wzoru: sqrt( (x1 - x2)^2 + (y1 - y2)^2 )
        float distance = (get_main_character_position().x - gameObject.transform.position.x) * (get_main_character_position().x - gameObject.transform.position.x) + (get_main_character_position().y - gameObject.transform.position.y) * (get_main_character_position().y - gameObject.transform.position.y);
        return Mathf.Sqrt(distance);
    }
    private void enemy_shooting()
    {
        direction = (main_character.transform.position - transform.position).normalized;
        projectile_enemy = Instantiate(bullet, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
        projectile_enemy.SetActive(true);
        projectile_enemy.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        projectile_enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        projectile_enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * 8;
        Destroy(projectile_enemy, 5f);
    }
    private void movement()
    {
        if (distance_to_character() >= 10)
        {
                transform.position = Vector2.MoveTowards(transform.position, get_main_character_position(), 8 * Time.deltaTime);
        }
        else
        {
            float random_range = Random.Range(0.3f, 1);
            if(random_generator_timer > 1 )
            {
                random_range = Random.Range(0.3f, 1);
            }
            if (bullet_time > random_range)
            {
                enemy_shooting();
                bullet_time = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
       if(collision.gameObject.ToString() == "bullet_pseudo(Clone) (UnityEngine.GameObject)")
       {
            clonning_enemies.nr_of_enemies--;
            if(Random.Range(0,100) < 10f){
                GameObject hearth = GameObject.Instantiate(heart, transform.position, Quaternion.identity);
                hearth.SetActive(true);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject.Find("GameController").GetComponent<PointSystem>().OnKillEnemy();
            
       }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(bullet_time < 1f)
        {
            bullet_time += Time.deltaTime;
        }
        if(random_generator_timer <1f)
        {
            random_generator_timer += Time.deltaTime;
        }    
        movement();
    }
}
