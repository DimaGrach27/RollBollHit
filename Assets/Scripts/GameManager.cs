using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    bool inGame;

    private void Start()
    {
        inGame = false;
        canvas.SetActive(true);
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (Input.touchCount > 0 || Input.anyKey && !inGame)
        {
            inGame = true;
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
           
    }
}
