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
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        _rb.velocity = Vector2.left * _moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var GM = _gameManager.GetComponent<GameManager>();
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GM._moveSpeed = 1;
        }
    }
}
