using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountView : MonoBehaviour
{
    /*
    [SerializeField] private TextMeshProUGUI _text;

    private IEnumerator CountUp(float delay, int start = 0)
    {
        var wait = new WaitForSeconds(delay);

        for (int i = start; i >= start; i++)
        {
            DisplayCountUp(i);
            yield return wait;
        }
    }

    public void DisplayCountUp(int count)
    {
        _text.text = count.ToString();
    }
    */
    
    [SerializeField] private TextMeshProUGUI _text;
    
    public void DisplayCount(int count)
    {
        _text.text = count.ToString();
    }
}
