using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int points = 0;
    public int killPoints = 100;

    private TextMeshProUGUI pointText;
    public void OnKillEnemy()
    {
        points += killPoints;
    }
    void Start()
    {
        pointText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Points: " + points;
    }
}
