using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[DefaultExecutionOrder(1)]
public class MenuStartButton : Debuggable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite buttonPointerUpSprite;
    [SerializeField] private Sprite buttonPointerDownSprite;
    private Image buttonSprite;
    private Button button;
    int easingID = -1;

    private MenuUI menuUI;

    private void Awake()
    {
        menuUI = transform.parent.parent.GetComponent<MenuUI>();
    }

    void Start()
    {
        button = GetComponent<Button>();
        PrintDebugLog($"Button null? : {button == null}");
        buttonSprite = transform.GetComponent<Image>();
    }
    
    [SerializeField] private GameObject girrafeSprite;
    Vector3 girrafeStartingPosition = new Vector3(300, -600);
    Vector3 girrafeOnButtonPosition = new Vector3(300, -150);

    public void OnPointerEnter(PointerEventData eventData)
    {

        LeanTween.cancel(girrafeSprite);

        if (!LeanTween.isTweening(easingID))
        easingID = LeanTween.moveLocal(girrafeSprite, girrafeOnButtonPosition,1f).uniqueId;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        
        LeanTween.moveLocal(girrafeSprite, girrafeStartingPosition,1f);
        

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
