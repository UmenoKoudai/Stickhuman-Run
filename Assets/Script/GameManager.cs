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

    /// <summary>�������ԕ\��</summary>
    [SerializeField] Text _timerText;
    /// <summary>����̃X�R�A</summary>
    [SerializeField] Text _distance;
    /// <summary>�x�X�g�X�R�A</summary>
    [SerializeField] Text _hiscoer;
    /// <summary>�Q�[���I�����̃X�R�A</summary>
    [SerializeField] Text _thisTimeDistance;
    /// <summary>�Q�[�������Q�[���I����</summary>
    [SerializeField] GameTime _gameTime = GameTime.Normal;
    /// <summary>���U���g��ʕ\��</summary>
    [SerializeField] GameObject _result;
    /// <summary>RunAudio�Đ�</summary>
    [SerializeField] GameObject _playerAudio;
    [SerializeField] int _acceleration;
    [SerializeField] float _decline;
    /// <summary>���̃G�t�F�N�g����</summary>
    GameObject _effect;
    /// <summary>��莞�ԂŃX�s�[�h�A�b�v</summary>
    int _speedUpCpunt = 1;
    /// <summary>����̈ړ�����</summary>
    int _moveDistance;
    /// <summary>�ߋ��ō��̈ړ�����</summary>
    int _bestDistance;
    /// <summary>�v���[�g�Ɣw�i�̑��x</summary>
    public int _moveSpeed = 1;
    /// <summary>�v���C���[���v���[�g�ɓ��������瑬�x�����ɖ߂�</summary>
    public bool _reset = false;
    /// <summary>�v���[�g�Ɛ�������Ԋu</summary>
    public float _intarval = 2f;
    /// <summary>��������</summary>
    float _timer;
    /// <summary>�P�b�Ԃ̃J�E���g</summary>
    float _count;
    /// <summary>�ߋ��ō��̈ړ�������ۑ�����class</summary>
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
            _distance.text = $"�ړ�����:{_moveDistance.ToString("000")}m";
            _hiscoer.text = $"�x�X�g{_bestDistance.ToString("000")}m";
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
                _thisTimeDistance.text = $"�X�R�A{_moveDistance.ToString("000")}m";
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
            Debug.LogWarning("�f�[�^������܂���");
            sco2._score = 0;
            OnSave(sco2);
            return sco2 = OnLoad();
        }

    }
}
enum GameTime
{
    /// <summary>�Q�[����</summary>
    Normal,
    /// <summary>�Q�[���I����</summary>
    Time0,
}
