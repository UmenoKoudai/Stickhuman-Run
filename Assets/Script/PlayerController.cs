using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BoxCollider2D _up;
    [SerializeField] AudioSource _jumpAudio;
    [SerializeField] BoxCollider2D _down;
    [SerializeField] AudioSource _slidingAudio;
    [SerializeField] BoxCollider2D _default;
    [SerializeField] AudioSource _defaultAudio;
    Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _up.enabled = false;
        _down.enabled = false;
        _default.enabled = true;
        _defaultAudio.Play();
        if (Input.GetKey(KeyCode.W))
        {
            UpMove();
            Debug.Log("è„ï˚å¸");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            DownMove();
            Debug.Log("â∫ï˚å¸");
        }
    }
    void UpMove()
    {
        _up.enabled = true;
        _default.enabled = false;
        _anim.Play("Jump");
        _jumpAudio.Play();
        _defaultAudio.Stop();
    }
    void DownMove()
    {
        _down.enabled = true;
        _default.enabled = false;
        _anim.Play("Sliding");
        _slidingAudio.Play();
        _defaultAudio.Stop();
    }
}



