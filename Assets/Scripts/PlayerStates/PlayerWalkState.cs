using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public float WalkSpeed = 5f;
    public float CurrentSpeed { get; private set; }
    float animatorMoveSpeed;

    public override void OnEnter()
    {

    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        HandleAnimatorMoveSpeed();
    }

    public override void OnFixedUpdate()
    {

    }

    void HandleAnimatorMoveSpeed()
    {
        animatorMoveSpeed = Mathf.Lerp(animatorMoveSpeed, CurrentSpeed, 10f * Time.deltaTime);
        player.Animator.SetFloat("MoveSpeed", animatorMoveSpeed);
    }
}
