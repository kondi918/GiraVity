using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAnimation : MonoBehaviour
{
    TextMeshProUGUI ScoreFinalValue;
    [SerializeField] ScoreSO scoreSO;
    private Vector3 orginalScale;
    private int easingID = -1;
    private int scaleEasingID = -1;
    private bool isScalingUp;
    private Vector3 animationScale = new Vector3(1.4f, 1.4f);
    private void Awake()
    {
        orginalScale = transform.localScale;
        ScoreFinalValue = transform.GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        EasingAnimation(scoreSO.score);
    }

    void EasingAnimation(int value)
    {
        easingID = LeanTween.value(0,value, 6f).setOnUpdate(IncreaseValue).setOnComplete(FinalScale).uniqueId;
        
    }
    void FinalScale()
    {
        LeanTween.cancel(scaleEasingID);
        LeanTween.scale(gameObject, orginalScale, 2f);
    }
    void IncreaseValue(float value)
    {
        ScoreFinalValue.text = value.ToString("00") + " points";
        if (!LeanTween.isTweening(scaleEasingID))
        {
            if (isScalingUp)
            {
                if(gameObject != null)
                {
                    scaleEasingID = LeanTween.scale(gameObject, orginalScale, 0.5f).uniqueId;
                    isScalingUp = false;
                }
            }
            else
            {
                if (gameObject != null)
                {
                    scaleEasingID = LeanTween.scale(gameObject, animationScale, 0.5f).uniqueId;
                    isScalingUp = true;
                }
            }
                

        }
    }
}
