using UnityEngine;

public class ForceMover : IMover
{
    private readonly Rigidbody _rigidbody;
    private float _force;

    public ForceMover(Rigidbody rigidbody, float force)
    {
        _rigidbody = rigidbody;
        _force = force;
    }

    public void Move(Vector3 direction)
    {
        Vector3 movememt = direction * _force;
        _rigidbody.AddForce(movememt, ForceMode.Force);
    }
}
