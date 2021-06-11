using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject helicopterPrefab;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnHelicopter), 3f, 3f);
    }

    private void SpawnHelicopter()
    {
        var rightSide = Random.Range(0, 2) == 0;
        var randomPos = rightSide ? new Vector3(-11, Random.Range(1, 4)) : new Vector3(11, Random.Range(1, 4));
        var helicopter = Instantiate(helicopterPrefab, randomPos, Quaternion.identity).GetComponent<Helicopter>();
        helicopter.RightSide = rightSide;
    }
}
