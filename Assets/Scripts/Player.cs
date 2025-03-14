using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public CapsuleCollider CapsuleCollider { get; private set; }

    [Header("Movement")]
    public Vector3 MoveDirection { get; private set; }
    float animatorMoveSpeed;

    [Header("States")]
    public PlayerState StartState;
    public PlayerState CurrentState { get; private set; }

    public PlayerIdleState PlayerIdleState;
    public PlayerWalkState PlayerWalkState;
    public PlayerDanceState PlayerDanceState;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        CapsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        ChangeState(StartState);
    }

    private void Update()
    {
        CurrentState?.OnUpdate();

        ReadMovementInput();
        ReadDanceInput();
    }

    private void FixedUpdate()
    {
        CurrentState?.OnFixedUpdate();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState?.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }

    void ReadMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        MoveDirection = new Vector3(x, 0, y);
    }

    void ReadDanceInput()
    {
        if (CurrentState == PlayerDanceState) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeState(PlayerDanceState);
        }
    }

    public void HandleAnimatorMoveSpeed(float targetSpeed)
    {
        animatorMoveSpeed = Mathf.Lerp(animatorMoveSpeed, targetSpeed, 10f * Time.deltaTime);
        Animator.SetFloat("MoveSpeed", animatorMoveSpeed);
    }

    /// <summary>
    /// Called via animator events
    /// </summary>
    public void EndDanceAnimation()
    {
        if (CurrentState != PlayerDanceState) return;
        ChangeState(PlayerIdleState);
    }
}