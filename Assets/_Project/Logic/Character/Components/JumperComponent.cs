using System;
using UnityEngine;

namespace _Project.Logic.Character.Components
{
    [Serializable]
    internal class JumperComponent
    {
        private const float CircleDivider =  0.5f;
        
        [SerializeField][Min(1.5f)] private float _jumpForce = 8.5f;
        [Space]
        [Header("Objects for interact with ground")]
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private CircleCollider2D _onGroundCollider;
        
        private Rigidbody2D _rigidbody2D;
        
        public void Initialize(Rigidbody2D rigidbody2D) => 
            _rigidbody2D = rigidbody2D;

        public bool IsGrounded => Physics2D.OverlapCircle(
            _onGroundCollider.transform.position,
            _onGroundCollider.radius * CircleDivider,
            _groundMask) is not null;

        public void TryJump()
        {
            if (IsGrounded is false)
                return;
            
            Jump();
        }
        
        private void Jump() => 
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}