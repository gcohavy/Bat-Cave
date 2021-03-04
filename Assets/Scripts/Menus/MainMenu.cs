using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _mainMenuEnter;
    [SerializeField] private AnimationClip _mainMenuExit;
    [SerializeField] private AnimationClip _titleTextAnimation;
    [SerializeField] private AnimationClip _aboutTextIn;
    [SerializeField] private AnimationClip _aboutTextOut;

    // Start is called before the first frame update
    void Start()
    {
        TitleTextAnimation();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            MainMenuExit();
        }
    }

    void StartAnimation(AnimationClip anim)
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = anim;
        _mainMenuAnimation.Play();
    }

    public void MainMenuExit()
    {
        StartAnimation(_mainMenuExit);
    }

    public void MainMenuEnter()
    {
        StartAnimation(_mainMenuEnter);
    }

    public void OnMenuEnterComplete()
    {
        StartAnimation(_titleTextAnimation);
    }

    public void OnMenuExitComplete()
    {
        UIManager.Instance.SetPregameMenuActive();
        gameObject.SetActive(false);
    }

    public void AboutTextIn()
    {
        StartAnimation(_aboutTextIn);
    }

    public void AboutTextOut()
    {
        StartAnimation(_aboutTextOut);
    }

    public void TitleTextAnimation()
    {
        StartAnimation(_titleTextAnimation);
    }
}
