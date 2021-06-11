using UnityEngine;

public class Entity : MonoBehaviour, IExplodable
{
    public event System.Action OnExplode;
    public void Explode()
    {
        OnExplode?.Invoke();
        Destroy(gameObject);
    }
}