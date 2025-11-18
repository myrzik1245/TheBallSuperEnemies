
public interface IBehaviour : IMovementControl
{
    void Entry();
    void Update(float deltaTime);
    void Exit();
}
