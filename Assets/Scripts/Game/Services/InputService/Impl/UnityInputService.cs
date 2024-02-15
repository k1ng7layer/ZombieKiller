using System;
using UnityEngine;
using Zenject;

namespace Game.Services.InputService.Impl
{
    public class UnityInputService : IInputService, ITickable
    {
        public Vector3 InputDirection { get; private set; }
        public event Action<int> MouseButtonDown;

        public Vector3 MousePosition => Input.mousePosition;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
                MouseButtonDown?.Invoke(0);
            
            if (Input.GetMouseButtonDown(1))
                MouseButtonDown?.Invoke(1);

            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");

            InputDirection = new Vector3(x, 0, z);
            
            Debug.Log($"Swipe: {Input.touches.Length}");
        }
    }
}