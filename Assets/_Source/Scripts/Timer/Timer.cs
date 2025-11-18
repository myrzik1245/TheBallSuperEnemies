public class Timer
{
    private float _startTime;

    public Timer(float startTime)
    {
        _startTime = startTime;
        Time = _startTime;
    }

    public float Time { get; private set; }

    public void UpdateTime(float deltaTime)
    {
        Time -= deltaTime;
    }

    public void Reset()
    {
        Time = _startTime;
    }
}
