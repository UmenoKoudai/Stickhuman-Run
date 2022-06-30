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
    float _time;
    float _intarval = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        _time += Time.deltaTime;
        int n = Random.Range(0, 2);
        if (_time > _intarval)
        {
            Instantiate(_wall, _wallPosition[n], transform.rotation);
            _time = 0;
        }
    }
}
