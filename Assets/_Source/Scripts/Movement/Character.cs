using UnityEngine;

public class Character : MonoBehaviour
{
    private IMover _mover;
    private IMovementControl _movementControl;

    public void Initialize(IMover mover, IMovementControl movementControl)
    {
        _mover = mover;
        _movementControl = movementControl;
    }

    private void FixedUpdate()
    {
        if (_movementControl.CanMove())
        {
            Vector3 direction = _movementControl.Direction;
            _mover.Move(direction);
        }
    }
}
