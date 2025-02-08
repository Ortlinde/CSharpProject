namespace StateMachines.Interfaces.Core;

public interface IStateMachineManager
{
    void RegisterStateMachine(string key, IStateMachine stateMachine);
    void UnregisterStateMachine(string key);
    IStateMachine GetStateMachine(string key);
    void SwitchStateMachine(string key);
    void UpdateAllStateMachines();
    void PhysicsUpdateAllStateMachines();
    void LateUpdateAllStateMachines();
}
