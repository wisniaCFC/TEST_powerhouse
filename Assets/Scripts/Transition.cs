using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private const string START_TRANSITION = "hide";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartTransition()
    {
        _animator.SetTrigger(START_TRANSITION);
    }

    public void LoadScene()
    {
        TransitionManager.ChangeScene();
    }
}
