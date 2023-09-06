using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrabGameManager : MonoBehaviour
{
    #region For Automatic Gameplay
    private static double TIME_TO_AUTO_PICK = 20;
    private static double TIME_TO_SHOW_TIMER = 10;

    private double _currentTimer = TIME_TO_AUTO_PICK;

    [SerializeField]
    public Text _timerLabel;
    [SerializeField]
    private List<Crab> _availableCrabs;

    private Coroutine _timerCoroutine;
    #endregion

    public bool CrabIsBusy = false;

    [SerializeField]
    private FinishSign _finishSign;
    [SerializeField]
    private Transition _transition;
    [SerializeField]
    private Sign _sign;

    private int _totalScore = 0;
    private bool _isFinished = false;
    private int _openedCrabsCount = 0;

    private ISequence _sequence;

    public bool IsFinished
    {
        get { return _isFinished; }
    }

    private void Awake()
    {
        _sequence = SequencesManager.Sequence;

        if (_sequence == null)
        {
            _sequence = new DefaultSequence();
        }

        _timerCoroutine = StartCoroutine(StartCountdown());
        _timerLabel.enabled = false;

        foreach(Crab c in _availableCrabs)
        {
            c.Initialize(this);
        }
    }

    private void Update()
    {
        if(_finishSign.IsFullyVisible)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _transition.StartTransition();
            }
        }
        
    }

    public void RemoveCrab(Crab crab)
    {
        _availableCrabs.Remove(crab);
    }

    public void ResetTimer()
    {
        _timerLabel.enabled = false;
        _currentTimer = TIME_TO_AUTO_PICK;
        StopCoroutine(_timerCoroutine);

        if (!_isFinished)
            _timerCoroutine = StartCoroutine(StartCountdown());
    }

    public void OnCrabClick(Crab crab)
    {
        CrabIsBusy = true;
        int value = GetNextCrabValue();
        _openedCrabsCount++;

        crab.SetValue(value);

        RemoveCrab(crab);
        ResetTimer();
    }

    public void AddScore(int value)
    {
        _totalScore += value;

        _finishSign.SetScore(_totalScore);
        _sign.SetCurrentValue(_totalScore);

        if (value == 0 || _openedCrabsCount == _sequence.RewardsSequence.Length)
        {
            StopCoroutine(_timerCoroutine);
            _isFinished = true;
            _finishSign.Show();
        }
    }

    int GetNextCrabValue()
    {
        return _sequence.RewardsSequence[_openedCrabsCount];
    }

    private void PickRandomCrab()
    {
        int rand = Random.Range(0, _availableCrabs.Count);

        _availableCrabs[rand].OnClick();
    }

    IEnumerator StartCountdown()
    {
        while (_currentTimer > TIME_TO_SHOW_TIMER)
        {
            yield return new WaitForSecondsRealtime(1);
            _currentTimer--;
        }
        _timerLabel.text = string.Format("00:{00}", _currentTimer);
        _timerLabel.enabled = true;


        while (_currentTimer > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            _currentTimer--;
            _timerLabel.text = string.Format("00:0{0}", _currentTimer);
        }

        PickRandomCrab();
    }
}
