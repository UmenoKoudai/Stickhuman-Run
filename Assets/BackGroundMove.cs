using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] float _changPosition;
    GameObject _gameManager;
    GameObject bGbefore;
    GameObject bGafter;
    int _moveSpeed;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        var gM = _gameManager.GetComponent<GameManager>();
        _moveSpeed = gM._moveSpeed;
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        if(transform.position.x <= _changPosition)
        {
            bGbefore.SetActive(false);
            bGafter.SetActive(true);
        }
    }
}
