namespace StateMachines.Interfaces.Core;

public interface IStateMachine
{
    void Initialize();
    void TransitionTo(IState newState);
    void PhysicsUpdate();
    void LogicUpdate();
    void LateUpdate();
}
