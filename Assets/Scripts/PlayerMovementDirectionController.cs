using System.Collections;
using UnityEngine;

namespace WarIO
{
    public class PlayerMovementDirectionController : MonoBehaviour, IMovementDirectionSource
    {
        public Vector3 movementDirection { get; private set; }

        void Update()
        {
            var horizontal  = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            movementDirection = new Vector3(horizontal, 0, vertical);
        }
    }
}