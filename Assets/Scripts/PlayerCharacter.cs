using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarIO
{
    [RequireComponent(typeof(CharacterMovementController))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerCharacter : MonoBehaviour
    {
        private CharacterMovementController characterMovementController;
        private IMovementDirectionSource movementDirectionSource;
        protected void Awake()
        {
            characterMovementController = GetComponent<CharacterMovementController>();
            movementDirectionSource = GetComponent<IMovementDirectionSource>();
        }

        // Update is called once per frame
        protected void Update()
        {
            var direction = movementDirectionSource.movementDirection;
            characterMovementController.Direction = direction; 
        }
    }

}