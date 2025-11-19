using UnityEngine;

public class IdolBehaviour : IBehaviour
{
    public Vector3 Direction => Vector3.zero;

    public bool CanMove()
    {
        return false;
    }

    public void Entry()
    {
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
    }
}
