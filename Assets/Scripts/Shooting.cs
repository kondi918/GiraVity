using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    private GameObject projectile;
    private Vector3 character_position;
    private Vector3 mouse_position;
    private Vector3 screenposition;
    private Vector3 gun_position;
    private Quaternion gun_rotation;
    private Vector3 direction;
    private float max_velocity = 30f;
    private float bullet_speed = 0.10f;

    private Camera mainCamera;
    private Transform giraffe;
    private Transform plasmagun;
    private Rigidbody2D rb;

    private AudioSource blasterSFX;

    private void Awake()
    {
        mainCamera = Camera.main;
        giraffe = GameObject.Find("giraffe").transform;
        plasmagun = GameObject.Find("plasmagun").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
        blasterSFX = GetComponent<AudioSource>();
    }

    private Vector3 get_screen_position()
    {
        return mainCamera.WorldToScreenPoint(get_character_position());
    }
    private Vector3 get_character_position()
    {
        return giraffe.position;
    }
    private Vector3 get_mouse_position()
    {
        return Input.mousePosition;
    }
    private void shoot()
    {
        screenposition = get_screen_position();
        mouse_position = get_mouse_position();
        gun_position = plasmagun.position;
        gun_rotation = plasmagun.rotation;
        character_position = get_character_position();
        direction = (mouse_position - screenposition).normalized;
        projectile = Instantiate(bullet, new Vector3(gun_position.x, gun_position.y, gun_position.z), Quaternion.identity, transform);
        projectile.transform.rotation = gun_rotation;
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * 100;

        rb.velocity = new Vector2(-direction.x, -direction.y) * max_velocity / 3;

        Destroy(projectile, 3f);

        blasterSFX.PlayOneShot(blasterSFX.clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet_speed >= 0.2)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                bullet_speed = 0;
                shoot();
            }
        }
        else
        {
            bullet_speed += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > max_velocity)
        {
            rb.velocity = gameObject.GetComponent<Rigidbody2D>().velocity.normalized * max_velocity;
        }
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity -= gameObject.GetComponent<Rigidbody2D>().velocity.normalized * 0.01f;
        }

        plasmagun.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(Input.mousePosition.y - mainCamera.WorldToScreenPoint(plasmagun.position).y, Input.mousePosition.x - mainCamera.WorldToScreenPoint(plasmagun.transform.position).x) * Mathf.Rad2Deg);
    }
}
