using UnityEngine;
using StateMachines.Core;

namespace StateMachines.Examples.Player;

public enum PlayerStateType
{
    Normal,
    Combat,
    Climbing,
    Swimming
}

public class PlayerStateMachineManager : BaseStateMachineManager<PlayerStateType>
{
    public static PlayerStateMachineManager? Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
