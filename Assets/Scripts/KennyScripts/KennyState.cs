public abstract class KennyState
{
    public abstract void OnEnter(KennyMachine machine);
    public abstract void OnExit(KennyMachine machine);
    public abstract void OnUpdate(KennyMachine machine);
}