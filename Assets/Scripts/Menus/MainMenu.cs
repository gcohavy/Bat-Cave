/// <summary>
/// This class serves to manage the Main Menu animations
/// </summary>

using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Keep track of the different Animation clips
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

    //Update is called at every frame
    void Update()
    {
        //Listen for Keypress so the user doesn't have to use their mouse
        if(Input.GetKeyDown(KeyCode.S))
        {
            MainMenuExit();
        }
    }

    //Consolidated code 
    void StartAnimation(AnimationClip anim)
    {
        _mainMenuAnimation.Stop();
        _mainMenuAnimation.clip = anim;
        _mainMenuAnimation.Play();
    }

    //Method to begin MainMenu Exiting Animation
    public void MainMenuExit()
    {
        StartAnimation(_mainMenuExit);
    }

    //Method to begin MainMenu Entering Animation
    public void MainMenuEnter()
    {
        StartAnimation(_mainMenuEnter);
    }

    //Method to run after Main menu animation finishes
    public void OnMenuEnterComplete()
    {
        StartAnimation(_titleTextAnimation);
    }

    //Method to run after Main Menu animation finishes
    public void OnMenuExitComplete()
    {
        UIManager.Instance.SetPregameMenuActive();
        gameObject.SetActive(false);
    }

    //Method to begin About information enter Animation
    public void AboutTextIn()
    {
        StartAnimation(_aboutTextIn);
    }

    //Method to begin About information Exiting Animation
    public void AboutTextOut()
    {
        StartAnimation(_aboutTextOut);
    }

    //Method to begin Title animation Animation
    public void TitleTextAnimation()
    {
        StartAnimation(_titleTextAnimation);
    }
}
