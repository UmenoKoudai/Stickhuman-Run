using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _timerText;
    [SerializeField] Text _distance;
    GameTime _gameTime = GameTime.Normal;
    int _moveDistance;
    public int _moveSpeed;
    public bool _reset = false;
    public float _intarval = 2f;
    float _timer;
    float _count;
    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _count += Time.deltaTime;
        float time = 60 - _timer;
        if(_gameTime == GameTime.Normal)
        {
            _timerText.text = $"TIME:{time.ToString("f2")}";
            _distance.text = $"à⁄ìÆãóó£:{_moveDistance.ToString("000")}m";
            if (_count >= 1)
            {
                SpeedUp();
                _count = 0;
                _moveDistance += _moveSpeed;
            }
            if (_reset)
            {
                _moveSpeed = 1;
                _intarval = 2f;
                _reset = false;
            }
        }
        if(_gameTime == GameTime.Time0)
        {
            _timerText.text = $"TIME:00.00";
            _moveSpeed = 0;
            _intarval = 9999f;
        }
        if(time <= 0)
        {
            _gameTime = GameTime.Time0;
        }
        
    }
    void SpeedUp()
    {
        _moveSpeed++;
        _intarval -= 0.05f;
    }
}
enum GameTime
{
    /// <summary>ÉQÅ[ÉÄíÜ</summary>
    Normal,
    /// <summary>ÉQÅ[ÉÄèIóπéû</summary>
    Time0,
}
