using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    [SerializeField]
    private Text _currentWinLabel;

    public void SetCurrentValue(int value)
    {
        _currentWinLabel.text = value + "$";
    }
}
