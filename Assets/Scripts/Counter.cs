using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputReader))]

public class Counter : MonoBehaviour
{
    [SerializeField] private int _startNumber;
    [SerializeField] private float _delay = 0.5f;

    private WaitForSeconds _wait;
    private int _currentNumber;
    private bool _isCounting = false;
    private InputReader _inputReader;
    
    public Action<int> OnNumberChanged;
    
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
        
        Debug.Log($"Стартовое значение _isCounting: {_isCounting}");
    }

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.OnMouseButtonClick.AddListener(OnStartCounting);
            Debug.Log("Подписались на клик!");
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.OnMouseButtonClick.RemoveListener(OnStartCounting);
            Debug.Log("Отписались от клика!");
        }
    }

    private void OnStartCounting()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            _currentNumber = _startNumber;
            StartCoroutine(CountRoutine());
            Debug.Log("Счётчик запущен!");
        }
        else
        {
            StopCoroutine(CountRoutine());
            _isCounting = false;
            Debug.Log("Счётчик остановлен!");
        }
    }

    private IEnumerator CountRoutine()
    {
        while (_isCounting)
        {
            _currentNumber++;
            Debug.Log("Текущее число: " + _currentNumber);
            OnNumberChanged?.Invoke(_currentNumber);
            yield return _wait;
        }
    }
}
