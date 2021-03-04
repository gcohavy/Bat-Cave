using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PregameMenu : MonoBehaviour
{
    [SerializeField] private Animation _pregameAnimationComponent;
    [SerializeField] private AnimationClip _countdownAnimation;
    [SerializeField] private AnimationClip _instructionAnimation;

    [SerializeField] TextMeshProUGUI[] _thingsToActivate;
    [SerializeField] GameObject[] _thingsToDeactivate;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            BeginCountdownAnimation();
        }
    }

    void Awake()
    {
        BeginInstructionAnimation();
    }

    public void BeginCountdownAnimation()
    {
        _pregameAnimationComponent.Stop();
        _pregameAnimationComponent.clip = _countdownAnimation;
        _pregameAnimationComponent.Play();
    }

    public void OnCountdownAnimationComplete()
    {
        GameManager.Instance.UpdateState(GameManager.GameState.RUNNING);
    }

    public void BeginInstructionAnimation()
    {
        _pregameAnimationComponent.Stop();
        _pregameAnimationComponent.clip = _instructionAnimation;
        _pregameAnimationComponent.Play();
    }

    public void SetToActive()
    {
        gameObject.SetActive(true);
        foreach( TextMeshProUGUI item in _thingsToActivate )
        {
            item.gameObject.SetActive(true);
        }
        foreach( GameObject item in _thingsToDeactivate )
        {
            item.gameObject.SetActive(false);
        }
    }
}
