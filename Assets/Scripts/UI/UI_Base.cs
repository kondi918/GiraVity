using UnityEngine;

public abstract class UI_Base : MonoBehaviour
{
    private GameObject container;

    protected virtual void Awake()
    {
        GetObjectsAndButtons();
        AddListeners();
    }

    protected abstract bool ToggleContainer(bool active);

    protected abstract void GetObjectsAndButtons();

    protected abstract void AddListeners();
}