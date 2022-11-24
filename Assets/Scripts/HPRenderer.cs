using UnityEngine;

public class HPRenderer : MonoBehaviour
{
    private collisionDetection collisionDetection;
    public GameObject hpIcon;

    // Start is called before the first frame update
    void Start()
    {
       
        collisionDetection = GameObject.Find("giraffe").GetComponent<collisionDetection>();
        for (int i = 0; i < collisionDetection.HP; i++)
        {
            GameObject icon = GameObject.Instantiate(hpIcon, new Vector3(0 + i * 50, 0, 0), Quaternion.identity);

            icon.transform.SetParent(GameObject.Find("Canvas").transform);
            icon.name = "HPIcon" + i;
        }
        hpIcon.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            HPIcon localHpIcon = GameObject.Find("HPIcon"+i).GetComponent<HPIcon>();
            if (i + 1 <= collisionDetection.HP)
            {
               localHpIcon.active = true;
            }
            else
            {
                localHpIcon.active = false;
            }
        }

    }
}
