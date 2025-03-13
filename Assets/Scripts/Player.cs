using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public CapsuleCollider CapsuleCollider { get; private set; }

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
}