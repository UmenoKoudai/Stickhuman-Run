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
    public void GameStart(string scneName)
    {
        SceneManager.LoadScene(scneName);
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
}
