using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public override void OnEnter()
    {
        player.Animator.CrossFadeInFixedTime("Movement", 0.1f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (player.MoveDirection.sqrMagnitude == 0)
        {
            player.ChangeState(player.PlayerIdleState);
            return;
        }

        player.HandleAnimatorMoveSpeed(1f);
    }

    public override void OnFixedUpdate()
    {
        player.Rigidbody.MovePosition(player.transform.position + player.WalkSpeed * Time.fixedDeltaTime * player.MoveDirection);
    }
}
