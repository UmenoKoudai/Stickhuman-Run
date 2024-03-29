using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] GameObject _nowScene;
    [SerializeField] GameObject _lastScene;
    [SerializeField] GameObject _doorClose;
    [SerializeField] float _angleSpeed;
    [SerializeField] AudioSource _audio;
    [SerializeField] bool _playerMove;
    [SerializeField] int _moveSpeed;
    Rigidbody2D _rb;
    float _angle;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(_playerMove)
        {
            _rb.velocity = Vector2.right * _moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            _anim.Play("SceneOut");
            _audio.Stop();
        }
    }
    public void AudioPlay()
    {
        if(_audio)
        {
            _audio.Play();
        }
    }
    public void AnimationPlay(string animname)
    {
        if (_anim)
        {
            _anim.Play(animname);
        }
    }
    public void LoadScene()
    {
        //SceneManager.LoadScene(scnename);
        _nowScene.gameObject.SetActive(false);
        _lastScene.gameObject.SetActive(true);
    }
    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}