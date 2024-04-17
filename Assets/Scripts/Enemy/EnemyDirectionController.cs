using WarIO.Movement;
using UnityEngine;

namespace WarIO.Enemy
{
    public class EnemyDirectionController : MonoBehaviour, IMovementDirectionSource
    {
        public Vector3 movementDirection { get; private set; }

        public void UpdateMovementDirection(Vector3 targetPosition)
        {
            var realDirection = targetPosition - transform.position;
            movementDirection = new Vector3(realDirection.x, 0f, realDirection.z).normalized;
            movementDirection.Normalize();
        }
    }
}