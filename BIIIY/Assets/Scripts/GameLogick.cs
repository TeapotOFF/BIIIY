using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogick : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _animator;
    private Object _enemyPrefab;
    private bool _gameInProgerss = true;

    public delegate void delegeateTakeDamage();
    public static event delegeateTakeDamage takeDamageEvent;
    private void Awake()
    {
        _enemyPrefab = Resources.Load("Prefab/Drone1");
        GameObject _enemyCopy = (GameObject)Instantiate(_enemyPrefab);
    }
    void Update()
    {
        if (_gameInProgerss)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerShoot();
            }
        }
    }
    private void PlayerShoot()
    {
        _animator.PlayerShoot();
        _animator.EnemyDamageAnimation();
        takeDamageEvent.Invoke();
    }
}
