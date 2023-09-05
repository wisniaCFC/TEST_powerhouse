using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishSign : MonoBehaviour
{
    private const string ANIM_FINISH = "finish";

    [SerializeField]
    private Text _totalWinLabel;
    [SerializeField]
    private Text _endLabel;

    private bool _isFullyVisible = false;
    private Animator _animator;

    public bool IsFullyVisible
    {
        get { return _isFullyVisible; }
        private set { }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetScore(int score)
    {
        _totalWinLabel.text = score + " $";
    }

    public void Show()
    {
        _animator.SetTrigger(ANIM_FINISH);
    }

    public void EnableEndRoundLabel() //triggerred by animation event
    {
        _endLabel.enabled = true;
        _isFullyVisible = true;
    }
}
