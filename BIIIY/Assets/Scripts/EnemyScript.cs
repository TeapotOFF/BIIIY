using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameLogick _gameLogick;
    private PlayerAnimation _enemyAnimation;
    private Object _enemyPrefab;
    public int health = 10;

    public System.Action dropCard;

    private void Awake()
    {
        _enemyAnimation = GameObject.Find("EnemyDamageEffect").GetComponent<PlayerAnimation>();
        GameLogick.takeDamageEvent += TakeDamage;
    }
    private void Start()
    {
        _enemyAnimation = GameObject.Find("EnemyDamageEffect").GetComponent<PlayerAnimation>();
        _enemyPrefab = Resources.Load("Prefab/Drone1");
    }
    public void TakeDamage()
    {
        health -= 1;
        EnemyDeath();
    }
    private void EnemyDeath()
    {
        if (health == 0)
        {
            _enemyAnimation.EnemyDeathAnimation();
            dropCard?.Invoke();
            SpawnEnemy();
            Destroy(gameObject);
        }
    }
    public void SpawnEnemy()
    {
        GameObject _enemy = (GameObject)Instantiate(_enemyPrefab);
    }
}
