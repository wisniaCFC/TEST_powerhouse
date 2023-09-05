using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CrabAdditionalAnim
{
    blink = 0,
    antenna = 1,
    swing_small = 2,
    swing_big = 3,
    max = 4
}

public enum CrabHiddenAnim
{
    blink = 0,
    look = 1,
    max = 2
}

public class Crab : MonoBehaviour
{
    public bool AlreadySelected => _alreadySelected;

    private const string ANIM_REVEAL = "reveal";
    private const string ANIM_BLINK = "blink";
    private const string ANIM_ANTENNA = "antenna";
    private const string ANIM_SWING_SMALL = "swing_small";
    private const string ANIM_SWING_BIG = "swing_big";
    private const string ANIM_LOOK = "look";
    private const string ANIM_SAND = "show";

    [SerializeField]
    private Text _valueText;
    [SerializeField]
    private List<Animator> _sandAnimations;

    private Animator _animator;
    private bool _alreadySelected = false;
    private int _value;
    private CrabGameManager _crabManager;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(ShowAdditionalAnim());
    }

    private void OnMouseDown()
    {
        OnClick();
    }

    public void Initialize(CrabGameManager manager)
    {
        _crabManager = manager;   
    }

    public void OnClick()
    {
        if (_crabManager.CrabIsBusy || _crabManager.IsFinished || _alreadySelected)
            return;

        _crabManager.OnCrabClick(this);
        _animator.SetTrigger(ANIM_REVEAL);
        _alreadySelected = true;

        foreach(var anim in _sandAnimations)
        {
            anim.SetTrigger(ANIM_SAND);
        }
    }

    public void UnblockCrabs() //triggerred by animation event
    {
        _crabManager.CrabIsBusy = false;
    }

    public void SetValue(int value)
    {
        _value = value;
        _valueText.text = value + "$";
    }

    public void ShowValue() //trigerred by animation event
    {
        _valueText.color = Color.black;
        _crabManager.AddScore(_value);
    }

    IEnumerator ShowAdditionalAnim()
    {
        float time = Random.Range(2f, 10f);
        yield return new WaitForSecondsRealtime(time);

        if (!_alreadySelected)
        {
            CrabAdditionalAnim anim = (CrabAdditionalAnim)Random.Range(0, (int)CrabAdditionalAnim.max);

            switch (anim)
            {
                case CrabAdditionalAnim.antenna:
                    _animator.SetTrigger(ANIM_ANTENNA);
                    break;
                case CrabAdditionalAnim.blink:
                    _animator.SetTrigger(ANIM_BLINK);
                    break;
                case CrabAdditionalAnim.swing_small:
                    _animator.SetTrigger(ANIM_SWING_SMALL);
                    break;
                case CrabAdditionalAnim.swing_big:
                    _animator.SetTrigger(ANIM_SWING_BIG);
                    break;
            }
        }
        else
        {
            CrabHiddenAnim anim = (CrabHiddenAnim)Random.Range(0, (int)CrabHiddenAnim.max);

            switch (anim)
            {
                case CrabHiddenAnim.look:
                    _animator.SetTrigger(ANIM_LOOK);
                    break;
                case CrabHiddenAnim.blink:
                    _animator.SetTrigger(ANIM_BLINK);
                    break;
            }
        }

        StartCoroutine(ShowAdditionalAnim());
    }
}
