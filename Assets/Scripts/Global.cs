using System;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static bool Paused;
    public int score;

    public static Global Instance;

    private void Start()
    {
        Instance = this;
        AudioManager.Instance.Play("soviet-march");
        InvokeRepeating(nameof(SpawnHelicopter), 2f, 3f);
    }

    private void SpawnHelicopter()
    {
        Pool.Instance.Spawn(nameof(Helicopter));
    }
}
