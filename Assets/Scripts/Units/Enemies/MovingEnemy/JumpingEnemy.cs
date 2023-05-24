using Controllers;
using UnityEngine;

namespace Units.Enemies.MovingEnemy
{
    public class JumpingEnemy : MonoBehaviour, IEnemy, IJumpable
    {
        public void Init(Vector3 position)
        {
        
        }

        public bool CanJump()
        {
            return true;
        }

        public void Jump()
        {
       
        }
    }
}