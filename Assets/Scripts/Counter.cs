using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]

public class Counter : MonoBehaviour
{
    [SerializeField] private int _startNumber;
    [SerializeField] private float _delay = 0.5f;

    private WaitForSeconds _wait;
    private InputReader _inputReader;
    
    private int _currentNumber;
    
    private bool _isCounting = false;
    
    public Action<int> NumberChanged;
    
    private void OnValidate()
    {
        if (_currentNumber < 0)
            _currentNumber = 0;
        
        if (_startNumber < 0)
            _startNumber = 0;
        
        if (_delay < 0)
            _delay = 0;
    }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _currentNumber = _startNumber;
        _wait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        if (_inputReader != null)
            _inputReader.MouseButtonClick += OnStartCounting;
    }

    private void OnDisable()
    {
        if (_inputReader != null)
            _inputReader.MouseButtonClick -= OnStartCounting;
    }

    private void OnStartCounting()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            _currentNumber = _startNumber;
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
            NumberChanged?.Invoke(_currentNumber);
            yield return _wait;
        }
    }
}
