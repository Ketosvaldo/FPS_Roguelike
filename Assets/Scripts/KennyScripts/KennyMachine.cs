using UnityEngine;

public class KennyMachine : MonoBehaviour
{
    KennyState currentState;
    readonly KennyState idleState = new Kenny_IdleState();
    readonly KennyState runState = new Kenny_RunState();
    readonly KennyState attackState = new Kenny_AttackState();
    readonly KennyState evadeState = new Kenny_EvadeState();
    public KennyState IdleState => idleState;
    public KennyState RunState => runState;
    public KennyState AttackState => attackState;
    public KennyState EvadeState => evadeState;

    private void Start()
    {
        SetState(IdleState);
    }

    private void Update()
    {
        currentState?.OnUpdate(this);
    }

    public void SetState(KennyState state)
    {
        currentState?.OnExit(this);
        currentState = state;
        currentState?.OnEnter(this);
    }
}