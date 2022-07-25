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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            _anim.Play("SceneOut");
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
}