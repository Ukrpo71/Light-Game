using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private DataManager _dataManager;

    private int _score;
    public int Score => _score;

    [SerializeField] private UnityEvent _playerLost;
    [SerializeField] private UnityEvent _playerWon;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        _playerData = _dataManager.Load();
    }

    public void PlayerWon()
    {
        if (_score > _playerData.BestScore)
        {
            _playerData.BestScore = _score;
            _dataManager.Save(_playerData);
        }
        _playerWon.Invoke();
    }

    public void PlayerLost() => _playerLost.Invoke();


    public void UpdateScore(int score)
    {
        _score = score;
    }

}
