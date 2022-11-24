using UnityEngine;

[ExecuteAlways]
public class ObjectSizeTween : MonoBehaviour
{
    private Vector3 initialScale;
    [SerializeField] private float scaleValue = 1.3f;
    [SerializeField] private float time = 0.5f;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    [ContextMenu("Tween Size")]
    public void ObjectSize_Tween()
    {
        LeanTween.scale(gameObject, new Vector3(scaleValue, scaleValue, scaleValue), time).setEaseInBounce().setOnComplete(TweenBack);
    }

    private void TweenBack() => LeanTween.scale(gameObject, initialScale, time).setEaseInBounce();
}
