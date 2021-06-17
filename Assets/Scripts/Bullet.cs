using UnityEngine;

public class Bullet : Entity
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bound"))
        {
            Destroy(gameObject);
            // Explode();
        } else if (other.CompareTag("Helicopter"))
        {
            var explodeObj = other.GetComponent<Entity>();
            explodeObj.OnExplode += OnTargetExplode;
            explodeObj.Explode();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Explosion.Explode(transform.position, .1f, 100f);
    }

    private void OnTargetExplode()
    {
        MenuHandler.Instance.IncreaseScore();
    }
}
