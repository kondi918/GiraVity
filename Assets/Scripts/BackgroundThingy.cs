using UnityEngine;

public class BackgroundThingy : MonoBehaviour
{
    private GameObject character;

    private void Awake()
    {
        character = GameObject.Find("giraffe");
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector3 character_position = character.transform.position;
        //Vector3 charOnBackground = gameObject.transform.position - character_position;


    }
}
