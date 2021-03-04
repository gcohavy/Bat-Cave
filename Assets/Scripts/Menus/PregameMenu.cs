/// <summary>
/// This class serves to manage the pregame menu
/// </summary>

using UnityEngine;
using TMPro;

public class PregameMenu : MonoBehaviour
{
    //Keep track of different animations
    [SerializeField] private Animation _pregameAnimationComponent;
    [SerializeField] private AnimationClip _countdownAnimation;
    [SerializeField] private AnimationClip _instructionAnimation;

    //keep track of things to reset when returning to this menu
    [SerializeField] TextMeshProUGUI[] _thingsToActivate;
    [SerializeField] GameObject[] _thingsToDeactivate;

    // Update is called once per frame
    void Update()
    {
        //Listen for key press
        if(Input.GetKeyDown(KeyCode.Return))
        {
            BeginCountdownAnimation();
        }
    }

    //Animate the instructions when activating this menu
    void Awake()
    {
        BeginInstructionAnimation();
    }

    //Method to start the Countdown animations
    public void BeginCountdownAnimation()
    {
        _pregameAnimationComponent.Stop();
        _pregameAnimationComponent.clip = _countdownAnimation;
        _pregameAnimationComponent.Play();
    }

    //Method to run after the countdown animation has been completed
    public void OnCountdownAnimationComplete()
    {
        GameManager.Instance.UpdateState(GameManager.GameState.RUNNING);
    }

    //Method to begin the instruction text animation
    public void BeginInstructionAnimation()
    {
        _pregameAnimationComponent.Stop();
        _pregameAnimationComponent.clip = _instructionAnimation;
        _pregameAnimationComponent.Play();
    }

    //public method to reactivate the components of this menu
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
