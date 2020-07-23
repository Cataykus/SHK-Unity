using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private Player _player;

    private int _enemies;

    private void Start()
    {
        _enemies = FindObjectsOfType<Enemy>().Length;
    }

    private void OnEnable()
    {
        _player.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _player.EnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        if(--_enemies == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _endScreen.SetActive(true);
    }
}
