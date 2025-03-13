using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    protected Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    
    public virtual void OnAwake() { }

    public abstract void OnEnter();

    public abstract void OnExit();

    public abstract void OnUpdate();

    public abstract void OnFixedUpdate();
}
