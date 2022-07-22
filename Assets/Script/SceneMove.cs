using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneMove : MonoBehaviour
{
    [SerializeField] GameObject _close;
    [SerializeField] GameObject _open;
    GameObject _anim;
    [SerializeField] GameObject _helpButton;

    private void Start()
    {
        _anim = GameObject.Find("DoorPosition");
    }


    public void GameStart(string scneName)
    {
        StartCoroutine(GS(scneName));
        if(_helpButton != null)
        {
            this.transform.position = new Vector2(-999f,-999f);
            _helpButton.transform.position = new Vector2(-999f, -999f);
        }
    }
    public void Title(string scneName)
    {
        SceneManager.LoadScene(scneName);
    }
    public void Help()
    {
        _close.SetActive(false);
        _open.SetActive(true);
    }
    IEnumerator GS(string scneName)
    {
        var Anim = _anim.GetComponent<Animator>();
        var Audio = GetComponent<AudioSource>();
        Anim.Play("DoorOpen");
        Audio.Play();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scneName);
    }
}


