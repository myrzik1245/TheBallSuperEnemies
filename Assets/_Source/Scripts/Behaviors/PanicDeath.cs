using UnityEngine;

public class PanicDeath : IBehaviour
{
    private Enemy _enemy;
    private ParticleSystem _deathParticlePrefab;

    public PanicDeath(Enemy enemy, ParticleSystem deathParticlePrefab)
    {
        _enemy = enemy;
        _deathParticlePrefab = deathParticlePrefab;
    }

    public Vector3 Direction => Vector3.zero;

    public bool CanMove()
    {
        return false;
    }

    public void Entry()
    {
        _enemy.Death();
        GameObject.Instantiate(_deathParticlePrefab, _enemy.transform.position, Quaternion.identity);
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
    }
}
