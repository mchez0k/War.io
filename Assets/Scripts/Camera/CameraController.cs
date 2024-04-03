using System;
using UnityEngine;
using WarIO;

namespace Assets.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 followCameraOffset = Vector3.zero;
        [SerializeField]
        private Vector3 rotationOffset = Vector3.zero;

        [SerializeField]
        private PlayerCharacter player;

        protected void Awake()
        {
            if (player == null)
                throw new NullReferenceException($"Follow camera cant follow null player - {nameof(player)}");
        }

        protected void LateUpdate()
        {
            Vector3 targetRotation = rotationOffset - followCameraOffset;
            transform.position = player.transform.position + followCameraOffset;
            transform.rotation = Quaternion.LookRotation(targetRotation, Vector3.up);
        }
    }
}