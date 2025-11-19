using UnityEngine;

public class InputMovementControl : IMovementControl
{
    private IInput _input;
    private float _movementThreshold;

    public InputMovementControl(IInput input, float movementThreshold)
    {
        _input = input;
        _movementThreshold = movementThreshold;
    }

    public Vector3 Direction => _input.Movement.normalized;

    public bool CanMove()
    {
        return _input.Movement.magnitude > _movementThreshold;
    }
}
