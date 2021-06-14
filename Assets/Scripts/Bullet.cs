using UnityEngine;
using Vector2 = UnityEngine.Vector2;

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
            Destroy(gameObject);
        }
    }

    private void OnTargetExplode()
    {
        MenuHandler.Instance.IncreaseScore();

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, .5f);
        foreach (var obj in collider2Ds)
        {
            Vector2 direction = obj.transform.position - transform.position;
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(direction * 350);
            }
        }
    }
}
