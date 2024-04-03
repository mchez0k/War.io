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

        public void Initialize(Vector3 direction, float maxFlyDistance, float flySpeed)
        {
            this.direction = direction;
            this.flySpeed = flySpeed;
            this.maxFlyDistance = maxFlyDistance;
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
