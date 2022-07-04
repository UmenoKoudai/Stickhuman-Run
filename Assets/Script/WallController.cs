using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class WallController : MonoBehaviour
{
    GameObject _gameManager;
    Rigidbody2D _rb;
    public int _moveSpeed = 1;
    bool _reset = false; 
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        var GM = _gameManager.GetComponent<GameManager>();
        _moveSpeed = GM._moveSpeed;
        if(_moveSpeed <= 25)
        {
            PlateMove(_moveSpeed);
        }
        else if(_moveSpeed > 25)
        {
            MaxSpeed();
        }
        if(transform.position.x <= -12f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var GM = _gameManager.GetComponent<GameManager>();
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            _reset = true;
            GM._reset = _reset;
        }
    }
    void PlateMove(int moveSpeed)
    {
        _rb.velocity = Vector2.left * moveSpeed;
    }
    void MaxSpeed()
    {
        _rb.velocity = Vector2.left * 25;
    }
}
