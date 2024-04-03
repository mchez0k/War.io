using UnityEngine;

namespace WarIO.Movement
{
    internal interface IMovementDirectionSource
    {
        Vector3 movementDirection { get; }
    }
}
