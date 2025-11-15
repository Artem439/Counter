using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int NumberButton = 0;
    
    public event Action MouseButtonClicked;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(NumberButton))
            MouseButtonClicked?.Invoke();
    }
}