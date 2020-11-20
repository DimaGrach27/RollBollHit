using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("ReloadScene", 0.9f);
        }
    }

    private void Update()
    {
        if(!SphereMoveble.isAlive)
            Invoke("ReloadScene", 2.5f);
    }

    void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
