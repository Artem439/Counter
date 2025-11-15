using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    public UnityEvent OnMouseButtonClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("кнопка нажата!");
            OnMouseButtonClick?.Invoke();
        }
    }
}