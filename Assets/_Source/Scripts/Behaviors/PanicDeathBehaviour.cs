using UnityEngine;

public class PanicDeathBehaviour : IBehaviour
{
    private IAlive _owner;
    private IReadOnlyPosition _ownerPostion;
    private ParticleSystem _deathParticlePrefab;

    public PanicDeathBehaviour(
        IAlive owner,
        ParticleSystem deathParticlePrefab,
        IReadOnlyPosition ownerPosition)
    {
        _owner = owner;
        _deathParticlePrefab = deathParticlePrefab;
        _ownerPostion = ownerPosition;
    }

    public Vector3 Direction => Vector3.zero;

    public bool CanMove()
    {
        return false;
    }

    public void Entry()
    {
        _owner.Death();
        GameObject.Instantiate(_deathParticlePrefab, _ownerPostion.Value, Quaternion.identity);
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
    }
}
