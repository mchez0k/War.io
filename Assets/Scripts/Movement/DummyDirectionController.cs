using System.Collections;
using UnityEngine;
using WarIO.Movement;

namespace Assets.Scripts.Movement
{
    public class DummyDirectionController : MonoBehaviour, IMovementDirectionSource
    {
        public Vector3 movementDirection { get; private set; }

        protected void Awake()
        {
            movementDirection = Vector3.zero;
        }
    }
}