using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] float _changPosition = -6f;
    GameObject _gameManager;
    GameObject bGbefore;
    GameObject bGafter;
    int _moveSpeed;
    Vector3 _position;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
        _position = transform.position;
    }

    void Update()
    {
        var gM = _gameManager.GetComponent<GameManager>();
        _moveSpeed = gM._moveSpeed;
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        if(transform.position.x <= _changPosition)
        {
            transform.position = _position;
            //bGbefore.SetActive(false);
            //bGafter.SetActive(true);
        }
    }
}
