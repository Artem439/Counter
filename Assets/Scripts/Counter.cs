using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    /*
    [SerializeField] private Button _button;
    [SerializeField] private CountView _count;
    [SerializeField] private int _addValue;
	
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _count.DisplayCountUp(_addValue);
    }
    */
    
    [SerializeField] private Button _button;
    [SerializeField] private CountView _countView;
    
    private int _currentCount = 0;
    private bool _isCounting = false;
    private Coroutine _countingCoroutine;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
        
        // Останавливаем корутину при отключении
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
        }
    }

    private void OnButtonClicked()
    {
        ToggleCounting();
    }

    private void ToggleCounting()
    {
        if (_isCounting)
        {
            StopCounting();
        }
        else
        {
            StartCounting();
        }
    }

    private void StartCounting()
    {
        _isCounting = true;
        _countingCoroutine = StartCoroutine(CountRoutine());
    }

    private void StopCounting()
    {
        _isCounting = false;
        
        if (_countingCoroutine != null)
        {
            StopCoroutine(_countingCoroutine);
            _countingCoroutine = null;
        }
    }

    private IEnumerator CountRoutine()
    {
        var wait = new WaitForSeconds(0.5f);
        
        while (_isCounting)
        {
            _currentCount++;
            _countView.DisplayCount(_currentCount);
            yield return wait;
        }
    }
}
