using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IReadOnlyPosition, IAlive
{
    [SerializeField] private float _movementSpeed;

    private Character _character;
    private AIMovementCointrol _movementControl;

    private IBehaviour _baseBehaviour;
    private IBehaviour _onPlayerBehaviour;

    public Vector3 Value => transform.position;

    public void Initialize(IBehaviour baseBehaviour, IBehaviour onPlayerBehavior)
    {
        _baseBehaviour = baseBehaviour;
        _onPlayerBehaviour = onPlayerBehavior;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        _character = GetComponent<Character>();

        _movementControl = new AIMovementCointrol(_baseBehaviour);

        _character.Initialize(new VelocityMover(rigidbody, _movementSpeed), _movementControl);
    }

    private void Update()
    {
        _movementControl.Update(Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            _movementControl.SetBehaviour(_onPlayerBehaviour);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            _movementControl.SetBehaviour(_baseBehaviour);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
