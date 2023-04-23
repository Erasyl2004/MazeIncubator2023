using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    private SaveTime timer;
    private void Start()
    {
       timer = new SaveTime(); 
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            timer.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
