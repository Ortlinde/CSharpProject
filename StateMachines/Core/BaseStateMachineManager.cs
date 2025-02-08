using StateMachines.Interfaces.Core;
using UnityEngine;

namespace StateMachines.Core;

public abstract class BaseStateMachineManager<T> : MonoBehaviour where T : Enum
{
    protected readonly Dictionary<T, IStateMachine> StateMachines = new();
    protected IStateMachine? CurrentStateMachine;



    public virtual void RegisterStateMachine(T key, IStateMachine stateMachine)
    {
        if (StateMachines.TryAdd(key, stateMachine))
        {
            stateMachine.Initialize();
        }
        else
        {
            Debug.LogWarning($"StateMachine for {key} already exists!");
        }
    }

    public virtual void UnregisterStateMachine(T key)
    {
        if (StateMachines.ContainsKey(key))
        {
            if (StateMachines[key] == CurrentStateMachine)
            {
                CurrentStateMachine = null;
            }
            StateMachines.Remove(key);
        }
    }

    public virtual IStateMachine? GetStateMachine(T key)
    {
        return StateMachines.TryGetValue(key, out var stateMachine) ? stateMachine : null;
    }

    public virtual void SwitchStateMachine(T key)
    {
        if (StateMachines.TryGetValue(key, out var newStateMachine))
        {
            CurrentStateMachine = newStateMachine;
        }
        else
        {
            Debug.LogWarning($"Attempted to switch to non-existent StateMachine for {key}");
        }
    }

    protected virtual void Update()
    {
        CurrentStateMachine?.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        CurrentStateMachine?.PhysicsUpdate();
    }

    protected virtual void LateUpdate()
    {
        CurrentStateMachine?.LateUpdate();
    }
}