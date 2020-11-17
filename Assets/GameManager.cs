using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    private void Start()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
           
    }
}
