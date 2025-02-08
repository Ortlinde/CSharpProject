using StateMachines.Interfaces.Core;
using StateMachines.Interfaces.Updates;

namespace StateMachines.Core;

public abstract class BaseStateMachine : IStateMachine
{
    private IState? _currentState;
    private IState? _initialState;


    public IState CurrentState
    {
        get
        {
            if (_currentState == null)
            {
                throw new InvalidOperationException("Current state is null");
            }
            return _currentState;
        }
        private set => _currentState = value;
    }

    public required IState InitialState
    {
        get => _initialState ?? throw new InvalidOperationException("Initial state is null");
        init
        {
            _initialState = value ?? throw new ArgumentNullException(nameof(value), "Initial state cannot be null");
        }
    }

    public void Initialize()
    {
        if (_initialState == null)
        {
            throw new InvalidOperationException("Cannot initialize StateMachine without setting InitialState");
        }
        TransitionTo(_initialState);
    }

    public void TransitionTo(IState newState)
    {
        _currentState?.Exit();

        _currentState = newState;

        _currentState?.Enter();
    }

    public void PhysicsUpdate()
    {
        // 如果需要物理更新，可以在這裡處理
        if (_currentState is IPhysicsState physicsState)
        {
            physicsState.PhysicsUpdate();
        }
    }

    public void LogicUpdate()
    {
        // 如果需要邏輯更新，可以在這裡處理
        if (_currentState is ILogicState logicState)
        {
            logicState.LogicUpdate();
        }
    }

    public void LateUpdate()
    {
        // 如果需要後期更新，可以在這裡處理
        if (_currentState is ILateState lateState)
        {
            lateState.LateUpdate();
        }
    }
}