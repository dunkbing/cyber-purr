using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject catPrefab;
    public GameObject cat;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        Global.Paused = true;
    }

    public void Resume()
    {
        Global.Paused = false;
        if (cat == null)
        {
            cat = Instantiate(catPrefab, new Vector3(0, -3.8f, 0), Quaternion.identity);
        }
        pauseMenu.SetActive(false);
        startMenu.SetActive(false);
        Time.timeScale = 1f;
        foreach (var go in Global.GameObjects)
        {
            Destroy(go);
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Global.Paused = true;
    }
}
