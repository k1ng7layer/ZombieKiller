using System;
using UnityEngine;

namespace Game.Services.InputService
{
    public interface IInputService
    {
        Vector3 InputDirection { get; }
        event Action<int> MouseButtonDown;
        Vector3 MousePosition { get; }
    }
}