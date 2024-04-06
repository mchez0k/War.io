using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WarIO.Shooting
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 direction;
        private float flySpeed;
        private float maxFlyDistance;
        private float currentFlyDistance;
        public float damage { get; private set; }

        public void Initialize(Vector3 direction, float maxFlyDistance, float flySpeed, float damage)
        {
            this.direction = direction;
            this.flySpeed = flySpeed;
            this.maxFlyDistance = maxFlyDistance;
            this.damage = damage;
        }

        protected void Update()
        {
            var delta = flySpeed * Time.deltaTime;
            currentFlyDistance += delta;
            transform.Translate(direction * delta);

            if (currentFlyDistance >= maxFlyDistance)
                Destroy(gameObject);
        }
    }
}
