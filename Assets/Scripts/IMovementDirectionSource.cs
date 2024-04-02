using UnityEngine;

namespace WarIO
{
    internal interface IMovementDirectionSource
    {
        Vector3 movementDirection { get; }
    }
}
