using System;
using Controllers;
using UnityEngine;

namespace Units.Enemies.JumpingEnemy
{
    public class JumpingEnemy : MonoBehaviour, IEnemy, IJumpable
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _enemyCollider;
        [SerializeField] private float _jumpForce = 20f;
        [SerializeField] private float _jumpCD = 2f;
        

        public bool CanJump()
        {
            _jumpCD -= Time.deltaTime;
            return _jumpCD <= 0;
        }

        public void Jump()
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _jumpCD = 2f;
        }
    }
}