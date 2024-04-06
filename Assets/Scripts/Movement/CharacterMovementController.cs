using UnityEngine;

namespace WarIO.Movement
{
    public class CharacterMovementController : MonoBehaviour
    {
        private static readonly float _sqrEpsilon = Mathf.Epsilon * Mathf.Epsilon;
        [SerializeField]
        private float speed = 4f;
        [SerializeField]
        private float runSpeedRatio = 2f;

        [SerializeField]
        private float maxRadiansDelta = 10f;
        public Vector3 movementDirection { get; set; }
        public Vector3 lookDirection { get; set; }

        private CharacterController characterController;

        protected void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }


        protected void Update()
        {
            Translate();

            if (maxRadiansDelta > 0f && lookDirection != Vector3.zero)
            {
                Rotate();
            }
        }

        private void Translate()
        {
            var delta = movementDirection * speed * (Input.GetKey(KeyCode.Space) ? runSpeedRatio : 1) * Time.deltaTime; // Реализация бега
            characterController.Move(delta);
        }

        private void Rotate()
        {
            var currentLookDirection = transform.rotation * Vector3.forward;
            float sqrMagnitude = (currentLookDirection - lookDirection).sqrMagnitude;

            if (sqrMagnitude > _sqrEpsilon)
            {
                var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection, Vector3.up), maxRadiansDelta * Time.deltaTime);
                transform.rotation = newRotation;
            }           
        }
    }
}