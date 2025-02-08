using UnityEngine;
using StateMachines.Core;

namespace StateMachines.Examples.Camera;

public enum CameraStateType
{
    Normal,
    Cinematic,
    Combat,
    Cutscene
}

public class CameraStateMachineManager : BaseStateMachineManager<CameraStateType>
{
    public static CameraStateMachineManager? Instance { get; private set; }

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
