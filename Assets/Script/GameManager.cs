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
    [SerializeField] Text _hiscoer;
    [SerializeField] Text _thisTimeDistance;
    [SerializeField] GameTime _gameTime = GameTime.Normal;
    [SerializeField] GameObject _result;
    int _moveDistance;
    int _bestDistance;
    public int _moveSpeed;
    public bool _reset = false;
    public float _intarval = 2f;
    float _timer;
    float _count;
    scoredata sco2 = new scoredata();
    void Start()
    {
        sco2 = OnLoad();
        _bestDistance = sco2._score;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        _count += Time.deltaTime;
        float time = 60 - _timer;
        if (_gameTime == GameTime.Normal)
        {
            _timerText.text = $"TIME:{time.ToString("f2")}";
            _distance.text = $"移動距離:{_moveDistance.ToString("000")}m";
            _hiscoer.text = $"ベスト{_bestDistance.ToString("000")}m";
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
                sco2._score = _bestDistance;
                OnSave(sco2);

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
            _thisTimeDistance.text = $"スコア{_moveDistance.ToString("000")}m";
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
        using (StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/savedata.json"))
        {
            string json = JsonUtility.ToJson(sco);
            writer.Write(json);
            writer.Flush();
            writer.Close();
        }
    }
    public scoredata OnLoad()
    {
        try
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/savedata.json"))
            {
                string datastr = "";
                datastr = reader.ReadLine();
                reader.Close();
                return JsonUtility.FromJson<scoredata>(datastr);
            }
        }
        catch
        {
            Debug.LogWarning("データがありません");
            return null;
        }

    }
}
enum GameTime
{
    /// <summary>ゲーム中</summary>
    Normal,
    /// <summary>ゲーム終了時</summary>
    Time0,
}
