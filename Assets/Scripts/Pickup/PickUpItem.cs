using WarIO.Shooting;
using UnityEngine;
using System;

namespace WarIO.Pickup
{
    public abstract class PickUpItem : MonoBehaviour
    {
        public event Action<PickUpItem> OnPickedUp;

        public virtual void PickUp(BaseCharacter character)
        {
            OnPickedUp?.Invoke(this);
        }
    }
}