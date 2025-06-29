using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Logic.Character.Components
{
    internal class InputService : IInputService
    {
        public event Action<Vector2> Moved;
        public event Action Jumped;
        public event Action Attacked;
        
        private readonly InputAction _moveAction;
        private readonly InputAction _jumpAction;
        private readonly InputAction _attackAction;
        
        private readonly Action<InputAction.CallbackContext> _movePerformed;
        private readonly Action<InputAction.CallbackContext> _moveCanceled;
        private readonly Action<InputAction.CallbackContext> _jumpPerformed;
        private readonly Action<InputAction.CallbackContext> _attackPerformed;

        public InputService()
        {
            _moveAction = new InputAction("Move", binding: "<Gamepad>/leftStick");
            _moveAction.AddCompositeBinding("Dpad")
                       .With("Left",  "<Keyboard>/a")
                       .With("Right", "<Keyboard>/d");

            _jumpAction = new InputAction("Jump",   binding: "<Keyboard>/space");
            _jumpAction.AddBinding("<Gamepad>/buttonSouth");

            _attackAction = new InputAction("Attack", binding: "<Mouse>/leftButton");
            _attackAction.AddBinding("<Gamepad>/rightTrigger");

            _movePerformed = context => Moved?.Invoke(context.ReadValue<Vector2>());
            _moveCanceled = _ => Moved?.Invoke(Vector2.zero);
            _jumpPerformed = _ => Jumped?.Invoke();
            _attackPerformed = _ => Attacked?.Invoke();
            
            EnableInputs();
        }

        public void Dispose() => 
            DisableInputs();

        private void EnableInputs()
        {
            _moveAction.performed += _movePerformed;
            _moveAction.canceled += _moveCanceled;
            _jumpAction.performed += _jumpPerformed;
            _attackAction.performed += _attackPerformed;

            _moveAction.Enable();
            _jumpAction.Enable();
            _attackAction.Enable();
        }

        private void DisableInputs()
        {
            _moveAction.Disable();
            _jumpAction.Disable();
            _attackAction.Disable();

            _moveAction.performed -= _movePerformed;
            _moveAction.canceled -= _moveCanceled;
            _jumpAction.performed -= _jumpPerformed;
            _attackAction.performed -= _attackPerformed;

            _moveAction.Dispose();
            _jumpAction.Dispose();
            _attackAction.Dispose();
        }
    }
}