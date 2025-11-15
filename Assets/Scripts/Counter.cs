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
    private Coroutine _countRoutine;
    
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
        _inputReader.MouseButtonClicked += OnStartCounting;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonClicked -= OnStartCounting;
    }

    private void OnStartCounting()
    {
        if (_isCounting)
            StopCounter();
        else
            StartCounter();
    }

    private void StartCounter()
    {
        if (_countRoutine != null)
            StopCoroutine(_countRoutine);
        
        _isCounting = true;
        _countRoutine = StartCoroutine(CountRoutine());
    }

    private void StopCounter()
    {
        if (_countRoutine == null)
            return;
        
        StopCoroutine(_countRoutine);
        _countRoutine = null;
        _isCounting = false;
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
