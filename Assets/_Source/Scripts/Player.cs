using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IReadOnlyPosition
{
    [SerializeField] private float _forceMovement;
    [SerializeField] private float _movementThreshold;

    private Character _character;

    public Vector3 Value => transform.position;

    public void Initialize(IInput input)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        _character = GetComponent<Character>();

        _character.Initialize(
            new ForceMover(rigidbody, _forceMovement),
            new InputMovementControl(input, _movementThreshold));
    }
}
