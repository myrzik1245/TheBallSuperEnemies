using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private BehaviourTypes _baseBehaviourType;
    [SerializeField] private BehaviourTypes _onPlayerBehaviourType;
    [SerializeField] private Player _player;
    [SerializeField] private PatrolPoint[] _patrolPoints;
    [SerializeField] private ParticleSystem _deathParticlePrefab;
    [SerializeField, Min(0.1f)] private float _timeToSwichDirection;

    public void Spawn()
    {
        Enemy spawnedEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        IBehaviour baseBehaviour = GetBehaviourByType(_baseBehaviourType, spawnedEnemy);
        IBehaviour onPlayerBehaviour = GetBehaviourByType(_onPlayerBehaviourType, spawnedEnemy);

        spawnedEnemy.Initialize(baseBehaviour, onPlayerBehaviour);
    }

    private IBehaviour GetBehaviourByType(BehaviourTypes behaviourType, Enemy spawnedEnemy)
    {
        switch (behaviourType)
        {
            case BehaviourTypes.Idol:
                return new Idol();

            case BehaviourTypes.Patrol:
                return new Patrol(_patrolPoints, spawnedEnemy);

            case BehaviourTypes.Wander:
                return new Wander(spawnedEnemy, _timeToSwichDirection);

            case BehaviourTypes.Flee:
                return new Flee(spawnedEnemy, _player);

            case BehaviourTypes.Chase:
                return new Chase(spawnedEnemy, _player);

            case BehaviourTypes.PanicDeath:
                return new PanicDeath(spawnedEnemy, _deathParticlePrefab);
            default:
                Debug.LogError($"This type of behavior: {behaviourType} is not supported.");
                return null;
        }
    }
}
