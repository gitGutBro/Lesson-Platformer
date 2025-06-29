using System;
using UnityEngine;

namespace _Project.Logic.Character.Components
{
    [Serializable]
    internal class MovementComponent
    {
        [SerializeField][Min(1.5f)] private float _speed;
        
        private Rigidbody2D _rigidbody2D;
        private Vector2 _currentDirection;

        public void Initialize(Rigidbody2D rigidbody2D) => 
            _rigidbody2D = rigidbody2D;
        
        public void SetDirection(Vector2 direction) =>
            _currentDirection = direction;

        public void PerformMovement()
        {
            Vector2 directionNormalized = _currentDirection.normalized;
            Vector2 velocity = _rigidbody2D.linearVelocity;
            velocity.x = directionNormalized.x * _speed;
            _rigidbody2D.linearVelocity = velocity;
        }
    }
}