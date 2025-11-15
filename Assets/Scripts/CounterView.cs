using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        if (_counter != null)
            _counter.OnNumberChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        if (_counter != null)
            _counter.OnNumberChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int number)
    {
        if (_textMeshPro != null)
            _textMeshPro.text = number.ToString();
    }
}