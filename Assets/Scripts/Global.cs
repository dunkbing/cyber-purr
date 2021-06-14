using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static bool Paused;
    public GameObject helicopterPrefab;
    public List<GameObject> gameObjects = new List<GameObject>();
    public int score;

    public static Global Instance;

    private void Start()
    {
        Instance = this;
        InvokeRepeating(nameof(SpawnHelicopter), 2f, 3f);
    }

    private void SpawnHelicopter()
    {
        var rightSide = Random.Range(0, 2) == 0;
        var randomPos = rightSide ? new Vector3(-11, Random.Range(1, 4)) : new Vector3(11, Random.Range(1, 4));
        var helicopter = Instantiate(helicopterPrefab, randomPos, Quaternion.identity).GetComponent<Helicopter>();
        helicopter.RightSide = rightSide;
        gameObjects.Add(helicopter.gameObject);
    }

    public void ClearGameObjects()
    {
        foreach (var go in gameObjects)
        {
            Destroy(go);
        }
    }
}
