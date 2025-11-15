using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    public UnityEvent onMouseButtonClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("кнопка нажата!");
            onMouseButtonClick?.Invoke();
        }
    }
}