using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseButtonClick;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MouseButtonClick?.Invoke();
    }
}