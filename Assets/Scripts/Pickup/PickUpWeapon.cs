using WarIO.Shooting;
using UnityEngine;

namespace WarIO.Pickup
{
    public class PickUpWeapon : PickUpItem
    {
        [SerializeField]
        private Weapon WeaponPrefab;

        public override void PickUp(BaseCharacter character)
        {
            base.PickUp(character);
            character.SetWeapon(WeaponPrefab);
        }
    }
}