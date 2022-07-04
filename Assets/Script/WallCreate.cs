using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class WallCreate : MonoBehaviour
{
    [SerializeField] Vector3[] _wallPosition;
    [SerializeField] GameObject _wall;
    GameObject _gameManager;
    float _time;
    float _intarval;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        _time += Time.deltaTime;
        int n = Random.Range(0, 2);
        var DM = _gameManager.GetComponent<GameManager>();
        _intarval = DM._intarval;
        if (_time > _intarval)
        {
            Instantiate(_wall, _wallPosition[n], transform.rotation);
            _time = 0;
        }
    }
}
