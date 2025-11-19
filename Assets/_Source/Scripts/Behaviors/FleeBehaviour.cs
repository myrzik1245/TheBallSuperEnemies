using UnityEngine;

public class FleeBehaviour : IBehaviour
{
    private IReadOnlyPosition _characterPosition;
    private IReadOnlyPosition _targetPosition;

    public FleeBehaviour(IReadOnlyPosition characterPosition, IReadOnlyPosition targetPosition)
    {
        _characterPosition = characterPosition;
        _targetPosition = targetPosition;
    }

    public Vector3 Direction => (_characterPosition.Value - _targetPosition.Value).normalized;

    public bool CanMove()
    {
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
        Debug.DrawLine(_characterPosition.Value, _characterPosition.Value + Direction);
    }
}
