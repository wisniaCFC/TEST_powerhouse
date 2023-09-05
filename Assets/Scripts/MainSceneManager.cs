using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    private const float BUTTONS_ANIM_TIME = 1.5f;

    [SerializeField]
    MainSceneButtons _buttons;
    [SerializeField]
    private WinSequence[] _sequences;
    [SerializeField]
    private Transition _transition;
    [SerializeField]
    private Girl _girl;

    private void Awake()
    {
        _buttons.Initialize(_sequences);
    }

    public void OnButtonClick(Button b)
    {
        int index = _buttons.GetButtonIndex(b);

        SequencesManager.Sequence = _sequences[index];
        //CrabsManager.SetSequenceAndResetScore(_sequences[index]);
        _girl.PressButton();
        StartCoroutine(WaitForAnimationEndAndStartGame());
    }

    public void GoToCrabGame()
    {
        _transition.StartTransition();
    }

    IEnumerator WaitForAnimationEndAndStartGame()
    {
        yield return new WaitForSecondsRealtime(BUTTONS_ANIM_TIME);
        GoToCrabGame();
    }
}
