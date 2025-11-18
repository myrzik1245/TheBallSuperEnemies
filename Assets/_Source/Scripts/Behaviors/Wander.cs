using UnityEngine;

public class Wander : IBehaviour
{
    private float _timeToSwichDirection;
    private Timer _timer;

    private IReadOnlyPosition _characterPosition;

    public Wander(IReadOnlyPosition characterPosition, float timeToSwichDirection)
    {
        _timeToSwichDirection = timeToSwichDirection;
        _characterPosition = characterPosition;

        _timer = new Timer(_timeToSwichDirection);
    }

    public Vector3 Direction { get; private set; }

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
        _timer.UpdateTime(deltaTime);

        if (_timer.Time <= 0)
        {
            Direction = RandomDirection();
            _timer.Reset();
        }

        Debug.DrawLine(_characterPosition.Value, _characterPosition.Value + Direction);
    }

    private Vector3 RandomDirection()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 direction = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));

        return direction.normalized;
    }
}
