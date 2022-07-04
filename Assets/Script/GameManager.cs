using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public class scoredata
    {
        public int _score;
    }

    [SerializeField] Text _timerText;
    [SerializeField] Text _distance;
    [SerializeField] GameTime _gameTime = GameTime.Normal;
    [SerializeField] GameObject _result;
    int _moveDistance;
    int _bestDistance;
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
            _distance.text = $"ˆÚ“®‹——£:{_moveDistance.ToString("000")}m";
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
            if(_bestDistance <= _moveDistance)
            {
                _bestDistance = _moveDistance;
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
            _result.gameObject.SetActive(true);
        }
        
    }
    void SpeedUp()
    {
        _moveSpeed++;
        _intarval -= 0.07f;
    }

    public void OnSave(scoredata sco)
    {
        StreamWriter writer;
        string json = JsonUtility.ToJson(sco);
        writer = new StreamWriter(Application.persistentDataPath + "/.json");
        writer.Write(json);
        writer.Flush();
        writer.Close();
    }
    public scoredata OnLoad()
    {
        string datastr = "";
        StringReader reader;
        reader = new StringReader(Application.persistentDataPath + "/.json");
        reader.Close();
        return JsonUtility.FromJson<scoredata>(datastr);
    }
}
enum GameTime
{
    /// <summary>ƒQ[ƒ€’†</summary>
    Normal,
    /// <summary>ƒQ[ƒ€I—¹</summary>
    Time0,
}
