using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active = true;
    public Sprite activeSprite;
    public Sprite inactiveSprite;
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            image.sprite = activeSprite;
        }
        else{
            image.sprite = inactiveSprite;
        }
    }
}
