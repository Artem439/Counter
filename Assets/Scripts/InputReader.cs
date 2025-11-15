using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseButtonClicked;

    private const int NumberButton = 0;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(NumberButton))
            MouseButtonClicked?.Invoke();
    }
}