using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneButtons : MonoBehaviour
{
    private Button[] _buttons;
    private Text[] _buttonsTexts;
    private Animator _buttonsAnimator;
    private ISequence[] _sequences;

    public void Initialize(ISequence[] sequences)
    {
        _sequences = sequences;
        _buttonsAnimator = GetComponent<Animator>();
        SetupButtons();
    }

    private void SetupButtons()
    {
        _buttons = GetComponentsInChildren<Button>();

        _buttonsTexts = new Text[_buttons.Length];

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttonsTexts[i] = _buttons[i].GetComponentInChildren<Text>();
        }

        InitTexts();
    }

    private void InitTexts()
    {
        for (int i = 0; i < _buttonsTexts.Length; i++)
        {
            string s = "";
            for (int j = 0; j < _sequences[i].RewardsSequence.Length; j++)
            {
                int value = _sequences[i].RewardsSequence[j];

                s += value + "$";

                if (value == 0)
                {
                    break;
                }

                if (j < _sequences[i].RewardsSequence.Length - 1)
                {
                    s += ", ";
                }
            }

            _buttonsTexts[i].text = s;
        }
    }

    public int GetButtonIndex(Button b)
    {
        int index = 0;
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i] == b)
            {
                index = i;
                break;
            }
        }

        _buttonsAnimator.SetInteger("chosenButton", index);

        return index;
    }

    public void ButtonClickAfterAnim()
    {

    }
}
