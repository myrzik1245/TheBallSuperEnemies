using UnityEngine;

public class AIMovementCointrol : IMovementControl
{
    private IBehaviour _behavior;

    public AIMovementCointrol(IBehaviour startehaviour)
    {
        _behavior = startehaviour;
        _behavior.Entry();
    }

    public Vector3 Direction => _behavior.Direction;

    public void SetBehaviour(IBehaviour behaviour)
    {
        _behavior?.Exit();
        _behavior = behaviour;
        _behavior.Entry();
    }

    public bool CanMove()
    {
        return _behavior.CanMove();
    }

    public void Update(float deltaTime)
    {
        _behavior.Update(deltaTime);
    }
}
