using TMPro;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int points = 0;
    private int killPoints = 10;

    private TextMeshProUGUI pointText;
    public void OnKillEnemy()
    {
        points += killPoints;
        pointText.text = "Points: " + points;
    }
    void Start()
    {
        pointText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
    }
}