using UnityEngine;

public class Bullet : Entity
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bound"))
        {
            Destroy(gameObject);
        } else if (other.CompareTag("Helicopter"))
        {
            var explodeObj = other.GetComponent<Entity>();
            explodeObj.OnExplode += OnTargetExplode;
            explodeObj.Explode();
        }
    }

    private void OnTargetExplode()
    {
        MenuHandler.Instance.IncreaseScore();
    }
}
