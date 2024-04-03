using UnityEngine;
using WarIO.Movement;
using WarIO.Shooting;

namespace WarIO
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon baseWeaponPrefab;
        [SerializeField]
        private Transform hand;

        private IMovementDirectionSource movementDirectionSource;

        private CharacterMovementController characterMovementController;
        private ShootingController shootingController;
        protected void Awake()
        {
            movementDirectionSource = GetComponent<IMovementDirectionSource>();

            characterMovementController = GetComponent<CharacterMovementController>();
            shootingController = GetComponent<ShootingController>();
        }

        private void Start()
        {
            shootingController.SetWeapon(baseWeaponPrefab, hand);
        }

        // Update is called once per frame
        protected void Update()
        {
            var direction = movementDirectionSource.movementDirection;
            characterMovementController.Direction = direction; 
        }
    }

}