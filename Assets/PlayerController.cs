using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerController : MonoBehaviour
{
    [SerializeField] BoxCollider2D _up;
    [SerializeField] BoxCollider2D _down;
    [SerializeField] BoxCollider2D _default;
    void Start()
    {
        
    }

    void Update()
    {
        _up.enabled = false;
        _down.enabled = false;
        _default.enabled = true;
        if (Input.GetKey(KeyCode.W))
        {
            UpMove();
            Debug.Log("ã•ûŒü");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            DownMove();
            Debug.Log("‰º•ûŒü");
        }
    }
    void UpMove()
    {
        _up.enabled = true;
        _default.enabled = false;
        //Debug.Log("ã•ûŒü");
    }
    void DownMove()
    {
        _down.enabled = true;
        _default.enabled = false;
        //Debug.Log("‰º•ûŒü");
    }
}



