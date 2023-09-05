using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    private const string ANIM_PRESS = "Press";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PressButton()
    {
        _animator.SetTrigger(ANIM_PRESS);
    }
}
