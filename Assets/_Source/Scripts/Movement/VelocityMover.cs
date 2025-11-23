using UnityEngine;

public class VelocityMover : IMover
{
    private Rigidbody _rigidbody;
    private float _speed;

    public VelocityMover(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void Move(Vector3 direction)
    {
        Vector3 movemnt = direction * _speed;
        _rigidbody.velocity = movemnt;
    }
}
