﻿using UnityEngine;

namespace WarIO.Shooting
{
    public class ShootingController : MonoBehaviour
    {
        public bool hasTarget => target != null;

        public Vector3 targetPosition => target.transform.position;

        private Weapon weapon;

        private Collider[] colliders = new Collider[2];
        private float nextShotTimerSec;
        private GameObject target;

        // Update is called once per frame
        protected void Update()
        {
            target = GetTarget();
            nextShotTimerSec -= Time.deltaTime;
            if (nextShotTimerSec < 0 )
            {
                if (hasTarget) weapon.Shoot(target.transform.position);

                nextShotTimerSec = weapon.shootRateSec;
            }
        }

        public void SetWeapon(Weapon weaponPrefab, Transform hand)
        {
            if (weapon != null)
            {
                Destroy(weapon.gameObject);
            }
            weapon = Instantiate(weaponPrefab, hand);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }

        private GameObject GetTarget()
        {
            GameObject target = null;

            var position = weapon.transform.position;
            var radius = weapon.shootRadius;
            var mask = LayerUtils.EnemyMask;

            var size = Physics.OverlapSphereNonAlloc(position, radius, colliders, mask);
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        target = colliders[i].gameObject;
                        break;
                    }
                }
            }
            return target;
        }
    }
}