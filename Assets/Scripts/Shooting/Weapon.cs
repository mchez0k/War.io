using UnityEngine;

namespace WarIO.Shooting
{
    public class Weapon : MonoBehaviour
    {
        [field: SerializeField]
        public Bullet BulletPrefab { get; private set; }
        [field: SerializeField]
        public float shootRadius { get; private set; } = 5f;
        [field: SerializeField]
        public float shootRateSec { get; private set; } = 1f;

        [SerializeField]
        private float bulletMaxFlyDistance = 10f;
        [SerializeField]
        private float bulletFlySpeed = 10f;
        [SerializeField]
        private Transform bulletSpawnPosition;

        public void Shoot(Vector3 targetPoint)
        {
            var bullet = Instantiate(BulletPrefab, bulletSpawnPosition.position, Quaternion.identity);

            var target = targetPoint - bulletSpawnPosition.position;
            target.y = 0;
            target.Normalize();

            bullet.Initialize(target, bulletMaxFlyDistance, bulletFlySpeed);
        }
    }
}