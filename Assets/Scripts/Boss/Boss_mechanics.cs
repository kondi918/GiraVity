using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_mechanics : MonoBehaviour
{
    [SerializeField] private int bossHP;

    private Slider bossHpSlider;
    public GameObject map_objects;
    public GameObject enemy_bullet;
    public GameObject asteroid;
    private GameObject new_asteroid;
    private float asteroid_rain_timer = 0;
    private float time_between_asteroid = 0;
    private GameObject projectile;
    private float auto_attack_timer = 0;
    private GameObject head_1;
    private GameObject head_2;
    private GameObject head_3;
    private GameObject head_4;

    void Start()
    {
        head_1 = GameObject.Find("head");
        head_2 = GameObject.Find("head (1)");
        head_3 = GameObject.Find("head (2)");
        head_4 = GameObject.Find("head (3)");
        bossHpSlider = transform.Find("BossUI").Find("Slider").GetComponent<Slider>();
    }

    public void TakeDamage(int damage)
    {

        bossHP -= damage;
        bossHpSlider.value -= 1;
        Debug.Log($"Boss hit! {bossHP} left");
        if (bossHP <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //SceneManager.LoadScene("MainMenuScene");
        map_objects.SetActive(true);
        GameObject main_character = GameObject.Find("giraffe");
        main_character.transform.position = new Vector3(0, 0, 0);
        GameObject black_hole = GameObject.Find("black_hole_official");
        black_hole.transform.localScale = new Vector3(1, 1, 0);
        while(Vector2.Distance(black_hole.transform.position,main_character.transform.position) < 40)
        {
            black_hole.transform.position = new Vector2(Random.Range(-99, 100),Random.Range(-90, 91));
        }
        GameObject.Find("Camera").GetComponent<Camera>().orthographicSize = 16;
    }
    private Vector3 direction_calculate(Vector3 head_position)
    {
        Vector3 direction = GameObject.Find("giraffe").transform.position - head_position;
        return direction;
    }
    private void auto_attack()
    {
        Vector3 direction = direction_calculate(head_1.transform.position);
        projectile = Instantiate(enemy_bullet, new Vector3(head_1.transform.position.x, head_1.transform.position.y, head_1.transform.position.z), Quaternion.identity);
        projectile.SetActive(true);
        projectile.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        projectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * 1;
        Destroy(projectile, 5f);
        direction = direction_calculate(head_2.transform.position);
        projectile = Instantiate(enemy_bullet, new Vector3(head_2.transform.position.x, head_2.transform.position.y, head_2.transform.position.z), Quaternion.identity);
        projectile.SetActive(true);
        projectile.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        projectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * 1;
        Destroy(projectile, 5f);
        direction = direction_calculate(head_3.transform.position);
        projectile = Instantiate(enemy_bullet, new Vector3(head_3.transform.position.x, head_3.transform.position.y, head_3.transform.position.z), Quaternion.identity);
        projectile.SetActive(true);
        projectile.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        projectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * 1;
        Destroy(projectile, 5f);
        direction = direction_calculate(head_4.transform.position);
        projectile = Instantiate(enemy_bullet, new Vector3(head_4.transform.position.x, head_4.transform.position.y, head_4.transform.position.z), Quaternion.identity);
        projectile.SetActive(true);
        projectile.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        projectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * 1;
        Destroy(projectile, 5f);

    }
    private void asteroid_attack()
    {
        if (time_between_asteroid >= 0.5f)
        {
            Vector3 main_character_position = GameObject.Find("giraffe").transform.position;
            time_between_asteroid = 0;
            new_asteroid = GameObject.Instantiate(asteroid, new Vector3(Random.Range(main_character_position.x - 15, main_character_position.x + 15), main_character_position.y + 20, 0), Quaternion.identity);
            new_asteroid.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            new_asteroid.SetActive(true);
            Destroy(new_asteroid, 5f);

        }
    }
    private void timers_checking()
    {
        if (auto_attack_timer < 2.5f)
        {
            auto_attack_timer += Time.deltaTime;
        }
        else
        {
            auto_attack();
            auto_attack_timer = 0;
        }
        if (asteroid_rain_timer < 20f)
        {
            asteroid_rain_timer += Time.deltaTime;
        }
        else if (asteroid_rain_timer >= 20f && asteroid_rain_timer < 30f)
        {
            asteroid_rain_timer += Time.deltaTime;
            time_between_asteroid += Time.deltaTime;
            asteroid_attack();
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
