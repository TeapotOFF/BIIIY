using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _animator;
    public static Object _enemyPrefab;
    public bool gameInProgerss = true;
    public int playerDamage = 1;

    public System.Action<int> takeDamageEvent;
    private void Awake()
    {
        _enemyPrefab = Resources.Load("Prefab/Drone1");
        GameObject _enemyCopy = (GameObject)Instantiate(_enemyPrefab);
    }
    void Update()
    {
        if (gameInProgerss)
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
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        takeDamageEvent.Invoke(playerDamage);
    }
    public void SpawnEnemy()
    {
        GameObject _enemy = (GameObject)Instantiate(_enemyPrefab);
    }
    public void SpawnCorotine(int time)
    {
        StartCoroutine(spawnCooldown(time));
    }
    IEnumerator spawnCooldown(int time)
    {
        yield return new WaitForSeconds(time);
        SpawnEnemy();
    }
}
