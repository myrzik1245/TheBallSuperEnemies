using UnityEngine;

public interface IMovementControl
{
    Vector3 Direction { get; }
    bool CanMove();
}
