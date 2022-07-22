using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class StartPlayer : MonoBehaviour
{
    GameObject _player;
    public void StartMove()
    {
        _player = GameObject.Find("Player");
        Animator anim = _player.GetComponent<Animator>();
        Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
        AudioSource _audio = GetComponent<AudioSource>();
        anim.Play("Run");
        _audio.Play();
        rb.velocity = new Vector2(5, 0);
    }
}
