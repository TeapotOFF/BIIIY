using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Transform _enemyDamage;
    private Animator _card;
    private Vector2 _enemyDamageOld;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _enemy;
    void Start()
    {
        _enemyDamageOld = _enemyDamage.position;
    }
    public void PlayerShoot()
    {
        _playerAnimator.SetTrigger("isShoot");
    }
    public void EnemyDamageAnimation()
    {
        _enemyDamage.position = new Vector2(Random.Range(_enemyDamageOld.x - 0.20f, _enemyDamageOld.x + 0.20f), 
        Random.Range(_enemyDamageOld.y - 0.20f, _enemyDamageOld.y + 0.20f));
        _enemy.SetTrigger("isDamage");
    }
    public void EnemyDeathAnimation()
    {
        _enemy.SetTrigger("isDeath");
    }
}
