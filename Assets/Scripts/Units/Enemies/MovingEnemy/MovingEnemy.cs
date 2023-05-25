using Controllers;
using Factories;
using UnityEngine;

namespace Units.Enemies.MovingEnemy
{
    public class MovingEnemy : MonoBehaviour, IEnemy, IMovable
    {
        // public void Init(Vector3 position)
        // {
        //
        // }

        public bool CanMove()
        {
            return true;
        }

        public void Move()
        {
            Debug.Log("MovingEnemy идет");
        }
    }
}