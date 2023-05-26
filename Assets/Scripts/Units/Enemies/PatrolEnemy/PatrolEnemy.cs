using System;
using Controllers;
using UnityEngine;

namespace Units.Enemies.PatrolEnemy
{
    public class PatrolEnemy : MonoBehaviour, IEnemy, IPatrolling
    {
        private const string GroundMask = "Ground";
        private const float GroundRayDistance = 0.81f;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _enemyCollider;
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _moveDirection = 1f;
        [SerializeField] private float _groundRayOffset = 0.2f;

        
        public void Patrol()
        {
            if (!NeedTurnAround()) 
                Move();
            else
                TurnAround();
        }

        private void Move()
        {
            _rigidbody.velocity = new Vector2(_moveDirection * _moveSpeed, _rigidbody.velocity.y);
        }

        public void TurnAround()
        {
            _moveDirection = -_moveDirection;
            _groundRayOffset = -_groundRayOffset;
        }

        public bool NeedTurnAround() => 
            !IsGrounded() || IsWallCollision();

        private bool IsGrounded()
        {
            int layerMask = LayerMask.GetMask(GroundMask);
            Vector2 rayDirection = new Vector2(_moveDirection + _groundRayOffset, -1);
            var hit = Physics2D.Raycast(_enemyCollider.bounds.center, rayDirection, GroundRayDistance, layerMask);
            Debug.DrawRay(_enemyCollider.bounds.center, rayDirection*GroundRayDistance, Color.red);
            return hit;
        }
        
        private bool IsWallCollision()
        {
            int layerMask = LayerMask.GetMask(GroundMask);
            var bounds = _enemyCollider.bounds;
            var rayStartPoint = _moveDirection > 0 ? new Vector2(bounds.max.x, bounds.center.y)  : new Vector2(bounds.min.x, bounds.center.y);
            var hit = Physics2D.BoxCast(rayStartPoint, new Vector2(0.1f, bounds.size.y - 0.3f),0f, new Vector2(_moveDirection,0),0.1f, layerMask);
        
            return hit;
        }
    }
}