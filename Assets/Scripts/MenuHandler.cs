using TMPro;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject catPrefab;
    public GameObject cat;

    // Text mesh
    public GameObject tmScoreObject;
    private TextMeshProUGUI _scoreText;
    public GameObject totalScoreTmObject;
    private TextMeshProUGUI _totalScoreText;

    public static MenuHandler Instance;

    private void Start()
    {
        Instance = this;
        _scoreText = tmScoreObject.GetComponent<TextMeshProUGUI>();
        _totalScoreText = totalScoreTmObject.GetComponent<TextMeshProUGUI>();
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
        Global.Instance.ClearGameObjects();
        _scoreText.SetText($"0");
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Global.Paused = true;
        _totalScoreText.SetText($"{Global.Instance.score}");
        Global.Instance.score = 0;
    }

    public void IncreaseScore()
    {
        _scoreText.SetText($"{++Global.Instance.score}");
    }
}
