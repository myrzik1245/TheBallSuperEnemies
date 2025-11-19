using System;
using UnityEngine;

public class PatrolBehaviour : IBehaviour
{
    private IReadOnlyPosition[] _patrolPoints;
    private IReadOnlyPosition _characterPosition;
    private int _pointIndex;

    private const float ArrivalThreshold = 0.5f;


    public PatrolBehaviour(IReadOnlyPosition[] patrolPoints, IReadOnlyPosition position)
    {
        _patrolPoints = patrolPoints;
        _characterPosition = position;

        _pointIndex = 0;
    }

    private IReadOnlyPosition CurrentPointPosition => _patrolPoints[_pointIndex];
    public Vector3 Direction => (CurrentPointPosition.Value - _characterPosition.Value).normalized;

    public bool CanMove()
    {
        if (CurrentPointPosition == null)
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
        Debug.DrawLine(_characterPosition.Value, CurrentPointPosition.Value);

        if (Vector3.Distance(_characterPosition.Value, CurrentPointPosition.Value) < ArrivalThreshold)
            SwichPoint();
    }

    private void SwichPoint()
    {
        _pointIndex++;

        if (_pointIndex >= _patrolPoints.Length)
            _pointIndex = 0;

        _pointIndex = Math.Clamp(_pointIndex, 0, _patrolPoints.Length);
    }
}
