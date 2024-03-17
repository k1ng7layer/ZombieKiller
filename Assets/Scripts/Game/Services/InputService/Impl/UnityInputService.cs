using System;
using UnityEngine;
using Zenject;

namespace Game.Services.InputService.Impl
{
    public class UnityInputService : IInputService, ITickable
    {
        public Vector3 InputDirection { get; private set; }
        public event Action<int> MouseButtonDown;
        public event Action BasicAttackPressed;

        public Vector3 MousePosition => Input.mousePosition;
        public event Action UseButtonPressed;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                BasicAttackPressed?.Invoke();
            }
            
            if (Input.GetMouseButtonDown(1))
                MouseButtonDown?.Invoke(1);

            var x = Input.GetAxisRaw("Horizontal");
            var z = Input.GetAxisRaw("Vertical");

            InputDirection = new Vector3(x, 0, z);
            
            Debug.Log($"Swipe: {Input.touches.Length}");
            
            if (Input.GetKeyDown(KeyCode.E))
                UseButtonPressed?.Invoke();
        }
    }
}