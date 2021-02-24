using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PregameMenu : MonoBehaviour
{
    [SerializeField] private Animation _pregameAnimationComponent;
    [SerializeField] private AnimationClip _countdownAnimation;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            BeginCountdownAnimation();
        }
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
}
