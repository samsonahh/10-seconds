using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public float WalkSpeed = 2f;
    public float RotationSpeed = 5f;

    Quaternion targetRotation;

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

        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }

    public override void OnFixedUpdate()
    {
        float angle = Mathf.Atan2(player.MoveDirection.x, player.MoveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        targetRotation = Quaternion.Euler(0, angle, 0);
        Vector3 targetForward = targetRotation * Vector3.forward;

        player.Rigidbody.MovePosition(player.transform.position + WalkSpeed * Time.fixedDeltaTime * targetForward);
    }
}
