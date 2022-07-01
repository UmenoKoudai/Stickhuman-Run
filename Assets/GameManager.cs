using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _timerText;
    GameObject _wallController;
    public int _moveSpeed;
    float _timer;
    float _count;
    void Start()
    {
        
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _count += Time.deltaTime;
        _timerText.text = $"TIME:{_timer.ToString("f2")}";
        
        if (_count >= 1)
        {
            SpeedUp();
            _count = 0;
        }
    }
    void SpeedUp()
    {
        _moveSpeed++;
    }
}
