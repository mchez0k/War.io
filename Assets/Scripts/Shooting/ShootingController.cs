using System.Collections;
using UnityEngine;

namespace WarIO.Shooting
{
    public class ShootingController : MonoBehaviour
    {
        private Weapon weapon;

        private float nextShotTimerSec;

        // Update is called once per frame
        protected void Update()
        {
            nextShotTimerSec -= Time.deltaTime;
            if (nextShotTimerSec < 0 )
            {
                var target = transform.forward * 100f;
                weapon.Shoot(target);

                nextShotTimerSec = weapon.shootRateSec;
            }
        }

        public void SetWeapon(Weapon weaponPrefab, Transform hand)
        {
            weapon = Instantiate(weaponPrefab, hand);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }
    }
}