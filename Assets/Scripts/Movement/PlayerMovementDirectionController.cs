using UnityEngine;

namespace WarIO.Movement
{
    public class PlayerMovementDirectionController : MonoBehaviour, IMovementDirectionSource
    {
        private new UnityEngine.Camera camera;
        public Vector3 movementDirection { get; private set; }

        protected void Awake()
        {
            camera = UnityEngine.Camera.main;
        }

        void Update()
        {
            var horizontal  = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var direction = new Vector3(horizontal, 0, vertical);
            direction = camera.transform.rotation * direction;
            direction.y = 0;
            movementDirection = direction.normalized;
        }
    }
}