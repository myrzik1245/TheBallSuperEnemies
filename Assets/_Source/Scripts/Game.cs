using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner[] _enemySpawners;

    private IInput _input = new KeyboarInput();

    private void Start()
    {
        _player.Initialize(_input);
        
        foreach(EnemySpawner spawner in _enemySpawners)
            spawner.Spawn();
    }
}
