using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuExitButton : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] private Sprite buttonPointerUpSprite;
    [SerializeField] private Sprite buttonPointerDownSprite;
    private Image buttonSprite;
    int easingID = -1;
    [SerializeField] private GameObject girrafeSprite;
    Vector3 girrafeStartingPosition = new Vector3(300, -600);
    Vector3 girrafeOnButtonPosition = new Vector3(300, -465);

    void Start()
    {
        buttonSprite = transform.GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.cancel(girrafeSprite);
        if (!LeanTween.isTweening(easingID))
            easingID = LeanTween.moveLocal(girrafeSprite, girrafeOnButtonPosition, 0.3f).uniqueId;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

          LeanTween.moveLocal(girrafeSprite, girrafeStartingPosition, 0.3f);
        

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonSprite.sprite = buttonPointerDownSprite;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        buttonSprite.sprite = buttonPointerUpSprite;
    }
}

