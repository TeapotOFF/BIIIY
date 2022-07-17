using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameLogic _gameLogick;
    private PlayerAnimation _enemyAnimation;
    public int health = 10;

    public System.Action dropCard;

    private void Awake()
    {
        _gameLogick = GameObject.Find("Player").GetComponent<GameLogic>();
        _enemyAnimation = GameObject.Find("EnemyDamageEffect").GetComponent<PlayerAnimation>();
        _gameLogick.takeDamageEvent += TakeDamage;
    }
    private void Start()
    {
        _enemyAnimation = GameObject.Find("EnemyDamageEffect").GetComponent<PlayerAnimation>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        EnemyDeath();
    }
    private void EnemyDeath()
    {
        Debug.Log(health);
        if (health <= 0)
        {
            _enemyAnimation.EnemyDeathAnimation();
            dropCard?.Invoke();
            _gameLogick.SpawnCorotine(2);
            _gameLogick.takeDamageEvent -= TakeDamage;
            Destroy(gameObject);
        }
    }
}