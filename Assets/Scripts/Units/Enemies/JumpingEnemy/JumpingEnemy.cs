using Controllers;
using UnityEngine;

namespace Units.Enemies.JumpingEnemy
{
    public class JumpingEnemy : MonoBehaviour, IEnemy, IJumpable
    {
        // public void Init(Vector3 position)
        // {
        //
        // }

        public bool CanJump()
        {
            return true;
        }

        public void Jump()
        {
            Debug.Log("JumpingEnemy прыгает");
        }
    }
}