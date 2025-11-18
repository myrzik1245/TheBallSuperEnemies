using UnityEngine;

public class Chase : IBehaviour
{
    private IReadOnlyPosition _position;
    private IReadOnlyPosition _targetPosition;

    private const float ArrivalThreshold = 0.5f;

    public Chase(IReadOnlyPosition position, IReadOnlyPosition targetPosition)
    {
        _position = position;
        _targetPosition = targetPosition;
    }

    public Vector3 Direction => (_targetPosition.Value - _position.Value).normalized;

    public bool CanMove()
    {
        if (Mathf.Sqrt(Vector3.Distance(_targetPosition.Value, _position.Value)) < ArrivalThreshold)
            return false;

        return true;
    }

    public void Entry()
    {
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
        Debug.DrawLine(_position.Value, _targetPosition.Value);
    }
}
