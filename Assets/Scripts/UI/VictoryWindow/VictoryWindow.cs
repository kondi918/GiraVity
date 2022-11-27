using System.Collections;
using UnityEngine;

public class VictoryWindow : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject meteorite;


    private Vector3 meteoritePosition = new Vector3(-200, 220);
    private Vector3 meteoriteFinalPosition = new Vector3(-620, -220);
    public ScoreAnimation animator;
    private int randomValue;
    private float timeToDestroy = 4f;
    public void OnClickDoneButton()
    {
        LeanTween.reset();
        //animator.Leandestroy();
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Start()
    {
        StartCoroutine(MeteoriteSpawningLoop());
    }

    IEnumerator MeteoriteSpawningLoop()
    {
        while (true)
        {

            StartCoroutine(SpawnMeteorite());
            yield return new WaitForSeconds(0.6f + Random.Range(0, 0.7f));
        }
    }
    IEnumerator SpawnMeteorite()
    {
        randomValue = Random.Range(0, 700);
        GameObject spawnMeteorite;
        spawnMeteorite = Instantiate(meteorite) as GameObject;
        spawnMeteorite.transform.parent = transform;
        spawnMeteorite.transform.localPosition = meteoritePosition + new Vector3(randomValue,0);
        LeanTween.moveLocal(spawnMeteorite, meteoriteFinalPosition + new Vector3(randomValue,0), timeToDestroy);
        yield return new WaitForSeconds(timeToDestroy + 1);
        Destroy(spawnMeteorite);

    }
}
