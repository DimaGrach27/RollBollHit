using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public static bool isFinish;

    [SerializeField] ParticleSystem part1;
    [SerializeField] ParticleSystem part2;

    private void Start()
    {
        isFinish = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            part1.Play();
            part2.Play();
            isFinish = true;
            Time.timeScale = 0.4f;
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
