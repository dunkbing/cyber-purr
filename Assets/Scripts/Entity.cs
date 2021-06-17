using UnityEngine;

public abstract class Entity : MonoBehaviour, IExplodable
{
    public event System.Action OnExplode;
    public void Explode()
    {
        OnExplode?.Invoke();
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }

}