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

    /// <summary>制限時間表示</summary>
    [SerializeField] Text _timerText;
    /// <summary>今回のスコア</summary>
    [SerializeField] Text _distance;
    /// <summary>ベストスコア</summary>
    [SerializeField] Text _hiscoer;
    /// <summary>ゲーム終了時のスコア</summary>
    [SerializeField] Text _thisTimeDistance;
    /// <summary>ゲーム中かゲーム終了か</summary>
    [SerializeField] GameTime _gameTime = GameTime.Normal;
    /// <summary>リザルト画面表示</summary>
    [SerializeField] GameObject _result;
    /// <summary>RunAudio再生</summary>
    [SerializeField] GameObject _playerAudio;
    [SerializeField] int _acceleration;
    [SerializeField] float _decline;
    /// <summary>風のエフェクト加速</summary>
    GameObject _effect;
    /// <summary>一定時間でスピードアップ</summary>
    int _speedUpCpunt = 1;
    /// <summary>今回の移動距離</summary>
    int _moveDistance;
    /// <summary>過去最高の移動距離</summary>
    int _bestDistance;
    /// <summary>プレートと背景の速度</summary>
    public int _moveSpeed = 1;
    /// <summary>プレイヤーがプレートに当たったら速度を元に戻す</summary>
    public bool _reset = false;
    /// <summary>プレートと生成する間隔</summary>
    public float _intarval = 2f;
    /// <summary>制限時間</summary>
    float _timer;
    /// <summary>１秒間のカウント</summary>
    float _count;
    /// <summary>過去最高の移動距離を保存するclass</summary>
    scoredata sco2 = new scoredata();
    void Start()
    {
        _effect = GameObject.Find("Effect");
        _playerAudio = GameObject.Find("Player");
        sco2 = OnLoad();
        _bestDistance = sco2._score;
    }

    [System.Obsolete]
    void Update()
    {
        _timer += Time.deltaTime;
        _count += Time.deltaTime;
        float time = 60 - _timer;
        var Effct = _effect.GetComponent<ParticleSystem>();
        var Audio = _playerAudio.GetComponent<AudioSource>();
        if (_gameTime == GameTime.Normal)
        {
            _timerText.text = $"TIME:{time.ToString("f2")}";
            _distance.text = $"移動距離:{_moveDistance.ToString("000")}m";
            _hiscoer.text = $"ベスト{_bestDistance.ToString("000")}m";
            if (_count >= _speedUpCpunt)
            {
                SpeedUp();
                Effct.startSpeed += 1;
                Audio.pitch += 0.01f;
            }
            if (_reset)
            {
                _moveSpeed = 1;
                _intarval = 2f;
                _reset = false;
                Effct.startSpeed = 5;
                Audio.pitch = 0.7f;
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
            if(_moveDistance >= 1000)
            {
                SceneManager.LoadScene("TrueEnd");
            }
            else
            {
                _thisTimeDistance.text = $"スコア{_moveDistance.ToString("000")}m";
                _gameTime = GameTime.Time0;
                _result.gameObject.SetActive(true);
            }
        }
        
    }
    void SpeedUp()
    {
        _moveSpeed += _acceleration;
        _intarval -= _decline;
        _count = 0;
        _moveDistance += _moveSpeed;
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
            sco2._score = 0;
            OnSave(sco2);
            return sco2 = OnLoad();
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
