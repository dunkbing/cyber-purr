using UnityEngine;
using Random = UnityEngine.Random;

public class Global : MonoBehaviour
{
    public static bool Paused;
    public GameObject helicopterPrefab;
    public GameObject menuUI;

    private void Awake()
    {
        Pause();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnHelicopter), 2f, 3f);
    }

    private void SpawnHelicopter()
    {
        var rightSide = Random.Range(0, 2) == 0;
        var randomPos = rightSide ? new Vector3(-11, Random.Range(1, 4)) : new Vector3(11, Random.Range(1, 4));
        var helicopter = Instantiate(helicopterPrefab, randomPos, Quaternion.identity).GetComponent<Helicopter>();
        helicopter.RightSide = rightSide;
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
}
