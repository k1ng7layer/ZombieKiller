using System;
using UnityEngine;

namespace Game.Services.InputService
{
    public interface IInputService
    {
        Vector3 InputDirection { get; }
        event Action BasicAttackPressed;
        Vector3 MousePosition { get; }
    }
}