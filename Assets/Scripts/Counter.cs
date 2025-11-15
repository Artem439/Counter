using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]

public class Counter : MonoBehaviour
{
    [SerializeField] private int startNumber;
    [SerializeField] private float delay = 0.5f;

    private WaitForSeconds _wait;
    private int _currentNumber;
    private bool _isCounting = false;
    private InputReader _inputReader;
    
    public Action<int> OnNumberChanged;
    
    private void OnValidate()
    {
        if (_currentNumber < 0)
            _currentNumber = 0;
        
        if (startNumber < 0)
            startNumber = 0;
        
        if (delay < 0)
            delay = 0;
    }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _currentNumber = startNumber;
        _wait = new WaitForSeconds(delay);
    }

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.onMouseButtonClick.AddListener(OnStartCounting);
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.onMouseButtonClick.RemoveListener(OnStartCounting);
        }
    }

    private void OnStartCounting()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            _currentNumber = startNumber;
            StartCoroutine(CountRoutine());
        }
        else
        {
            StopCoroutine(CountRoutine());
            _isCounting = false;
        }
    }

    private IEnumerator CountRoutine()
    {
        while (_isCounting)
        {
            _currentNumber++;
            OnNumberChanged?.Invoke(_currentNumber);
            yield return _wait;
        }
    }
}
