using UnityEngine;

public class Explosion : MonoBehaviour
{
    private int force = 20;
    // Start is called before the first frame update
    void Start()
    {
        Explode(transform.position, .5f, force);
    }

    public static void Explode(Vector3 position, float radius, float force)
    {
        Collider2D[] collider2Ds = new Collider2D[8];
        Physics2D.OverlapCircleNonAlloc(position, radius, collider2Ds);
        foreach (var obj in collider2Ds)
        {
            Vector2 direction = obj.transform.position - position;
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(direction * force, ForceMode2D.Impulse);
            }
        }
    }
}
