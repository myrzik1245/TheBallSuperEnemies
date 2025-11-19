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
                return new IdolBehaviour();

            case BehaviourTypes.Patrol:
                return new PatrolBehaviour(_patrolPoints, spawnedEnemy);

            case BehaviourTypes.Wander:
                return new WanderBehaviour(spawnedEnemy, _timeToSwichDirection);

            case BehaviourTypes.Flee:
                return new FleeBehaviour(spawnedEnemy, _player);

            case BehaviourTypes.Chase:
                return new ChaseBehaviour(spawnedEnemy, _player);

            case BehaviourTypes.PanicDeath:
                return new PanicDeathBehaviour(spawnedEnemy, _deathParticlePrefab, spawnedEnemy);
            default:
                Debug.LogError($"This type of behavior: {behaviourType} is not supported.");
                return null;
        }
    }
}
