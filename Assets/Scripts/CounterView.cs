using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    
    private Counter _counter;

    private void Awake()
    {
        _counter = GetComponent<Counter>();
    }

    private void OnEnable()
    {
        if (_counter != null)
            _counter.NumberChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        if (_counter != null)
            _counter.NumberChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(int number)
    {
        if (_textMeshPro != null)
            _textMeshPro.text = number.ToString();
    }
}