using UnityEngine;
using WarIO.Movement;
using WarIO.Shooting;

namespace WarIO
{
    [RequireComponent(typeof(CharacterMovementController), typeof(ShootingController))]
    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField]
        private Weapon baseWeaponPrefab;
        [SerializeField]
        private Transform hand;

        [SerializeField]
        private float health = 2f;

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
            var lookDirection = direction;
            if (shootingController.hasTarget) lookDirection = (shootingController.targetPosition - transform.position).normalized;
            characterMovementController.movementDirection = direction;
            characterMovementController.lookDirection = lookDirection;

            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }

        protected void OnTriggerEnter(Collider other)
        {
            if (LayerUtils.isBullet(other.gameObject))
            {
                var bullet = other.gameObject.GetComponent<Bullet>();
                health -= bullet.damage;
                Debug.Log($"Пуля попала по {gameObject.name}");

                Destroy(other.gameObject);
            }
        }
    }

}