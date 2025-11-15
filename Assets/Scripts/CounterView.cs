using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Counter counter;

    private void OnEnable()
    {
        if (counter != null)
        {
            counter.OnNumberChanged += UpdateDisplay;
        }
    }

    private void OnDisable()
    {
        if (counter != null)
        {
            counter.OnNumberChanged -= UpdateDisplay;
        }
    }

    private void UpdateDisplay(int number)
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = number.ToString();
        }
    }
}