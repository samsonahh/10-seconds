public class PlayerDanceState : PlayerState
{
    public override void OnEnter()
    {
        player.Animator.CrossFadeInFixedTime("GangnamStyle", 0.1f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (player.MoveDirection.sqrMagnitude > 0)
        {
            player.ChangeState(player.PlayerWalkState);
            return;
        }

        player.HandleAnimatorMoveSpeed(0f);
    }

    public override void OnFixedUpdate()
    {

    }
}
