using UnityEngine;
using _Project.Logic.Character.Components;

namespace _Project.Logic.Character.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private MovementComponent _movement;
        [SerializeField] private JumperComponent _jumper;
        
        private IInputService _inputService;

        private void Awake()
        {
            Rigidbody2D component = GetComponent<Rigidbody2D>();
            
            _movement.Initialize(component);
            _jumper.Initialize(component);
            _inputService = new InputService();
            
            _inputService.Moved += OnMove;
            _inputService.Jumped += OnJump;
        }

        private void FixedUpdate() => 
            _movement.PerformMovement();

        private void OnDestroy()
        {
            _inputService.Moved -= OnMove;
            _inputService.Jumped -= OnJump;
            
            _inputService?.Dispose();
        }

        private void OnMove(Vector2 direction) =>
            _movement.SetDirection(direction);

        private void OnJump() =>
            _jumper.TryJump();
    }
}