using UnityEngine;

public class Fragment : MonoBehaviour
{
    private Collider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Fragment"))
        {
            _collider2D.isTrigger = true;
        }
    }
}
