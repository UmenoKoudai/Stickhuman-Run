using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class WallController : MonoBehaviour
{
    Rigidbody2D _rb;
    int _moveSpeed = 1;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = Vector2.left * _moveSpeed;
    }
}
