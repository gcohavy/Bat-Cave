using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animation _mainMenuAnimation;
    [SerializeField] private AnimationClip _mainMenuEnter;
    [SerializeField] private AnimationClip _mainMenuExit;
    [SerializeField] private AnimationClip _titleTextAnimation;

    // Start is called before the first frame update
    void Start()
    {
        StartAnimation(_titleTextAnimation);
    }

    void StartAnimation(AnimationClip anim)
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = anim;
        _mainMenuAnimation.Play();
    }

    public void MenuMenuExit()
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
}
