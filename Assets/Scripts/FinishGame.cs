﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("ReloadScene", 1f);
        }
    }

    void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}