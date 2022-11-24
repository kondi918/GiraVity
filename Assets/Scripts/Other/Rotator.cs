using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speed = 0f;

    [SerializeField] private bool ForwardX = false;
    [SerializeField] private bool ForwardY = false;
    [SerializeField] private bool ForwardZ = false;

    [SerializeField] private bool ReverseX = false;
    [SerializeField] private bool ReverseY = false;
    [SerializeField] private bool ReverseZ = false;

    void Update()
    {
        if (ForwardX == true)
        {
            transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ForwardY == true)
        {
            transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }
        if (ForwardZ == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }

        if (ReverseX == true)
        {
            transform.Rotate(-Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ReverseY == true)
        {
            transform.Rotate(0, -Time.deltaTime * speed, 0, Space.Self);
        }
        if (ReverseZ == true)
        {
            transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
        }
    }
}