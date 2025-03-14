using TMPro;
using UnityEngine;

public class PlayerDanceState : PlayerState
{
    public AudioSource AudioSource;
    public TMP_Text TimerText;

    float timer;

    public override void OnEnter()
    {
        player.Animator.CrossFadeInFixedTime("GangnamStyle", 0.1f);
        AudioSource.Play();
    }

    public override void OnExit()
    {
        AudioSource.Pause();
    }

    public override void OnUpdate()
    {
        if (player.MoveDirection.sqrMagnitude > 0)
        {
            player.ChangeState(player.PlayerWalkState);
            return;
        }

        player.HandleAnimatorMoveSpeed(0f);

        timer += Time.deltaTime;
        TimerText.text = GetFormattedFloatTimer(timer);
    }

    public override void OnFixedUpdate()
    {

    }

    public string GetFormattedFloatTimer(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
