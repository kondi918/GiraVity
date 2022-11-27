using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collisionDetection_HP : MonoBehaviour
{
    public static int HP = 2;
    public Sprite hp_inactiveSprite;
    public Sprite hp_activeSprite;
    public GameObject hpIcon;

    private void Start()
    {
        {
            for (int i = 0; i <= HP; i++)
            {
                GameObject icon = GameObject.Instantiate(hpIcon, new Vector3(0 + i * 50, 0, 0), Quaternion.identity);

                icon.transform.SetParent(GameObject.Find("Canvas").transform);
                icon.name = "HPIcon" + i;
            }
            hpIcon.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.ToString() == "enemy_bullet(Clone) (UnityEngine.GameObject)")
        {
            Image localHpIcon = GameObject.Find("HPIcon"+(HP)).GetComponent<Image>();
            localHpIcon.sprite = hp_inactiveSprite;
            HP -= 1;
        }
        if (collision.gameObject.ToString() == "asteroid(Clone) (UnityEngine.GameObject)")
        {
            Image localHpIcon = GameObject.Find("HPIcon" + (HP)).GetComponent<Image>();
            localHpIcon.sprite = hp_inactiveSprite;
            HP -= 1;
        }
        if (collision.gameObject.ToString() == "hp_hearts_0(Clone) (UnityEngine.GameObject)")
        {
            HP += 1;
            Destroy(collision.gameObject);
            if(HP > 2)
            {
                HP = 2;
            }
            else
            {
                Image localHpIcon = GameObject.Find("HPIcon" + (HP)).GetComponent<Image>();
                localHpIcon.sprite = hp_activeSprite;
            }
        }
        if (HP == -1)
        {
            clonning_enemies.nr_of_enemies = 0;
            PlayerPrefs.SetInt("Score", GameObject.Find("GameController").GetComponent<PointSystem>().points);
            PlayerPrefs.SetInt("Lost", 1);
            HP = 2;
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
