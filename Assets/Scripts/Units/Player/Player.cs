using Controllers;
using UnityEngine;

namespace Units.Player
{
    public class Player : MonoBehaviour, IPlayer, IMovable, IJumpable, IUnitControlInputListener
    {
        private const string GroundMask = "Ground";
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _playerCollider;
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private int _maxJumps = 2;
        private int jumpsCount;

        public bool IsJumpButtonClicked { get; set; }
        public float MoveDirection { get; set; }
        

        public bool CanMove() => 
            !IsWallCollision(MoveDirection);

        public void Move()
        {
            _rigidbody.velocity = new Vector2(MoveDirection * _moveSpeed, _rigidbody.velocity.y);
        }

        public bool CanJump() => 
            IsJumpButtonClicked && (IsGrounded() || jumpsCount < _maxJumps);

        public void Jump()
        {
            if (IsGrounded())
                ResetJumpsCount();
            _rigidbody.velocity = Vector2.up * _jumpForce;
            jumpsCount++;
        }

        private bool IsGrounded()
        {
            int layerMask = LayerMask.GetMask(GroundMask);
            var hit = Physics2D.BoxCast(_playerCollider.bounds.center, _playerCollider.bounds.size, 0f, Vector2.down,
                0.2f, layerMask);
            return hit;
        }
    
        private bool IsWallCollision(float direction)
        {
            int layerMask = LayerMask.GetMask(GroundMask);
            var bounds = _playerCollider.bounds;
            var rayStartPoint = direction > 0 ? new Vector2(bounds.max.x, bounds.center.y)  : new Vector2(bounds.min.x, bounds.center.y);
            var hit = Physics2D.BoxCast(rayStartPoint, new Vector2(0.1f, bounds.size.y - 0.3f),0f, new Vector2(direction,0),0.1f, layerMask);
        
            return hit;
        }

        private void ResetJumpsCount() => jumpsCount = 0;
    }
}