using UnityEngine;

public class Cat : Entity
{
    public GameObject catExplode;
    public GameObject explosionEffect;
    private void Start()
    {
        OnExplode += (TriggerAnimation);
    }

    private void TriggerAnimation()
    {
        Debug.Log("cat explode animation");
        var position = transform.position;
        Instantiate(catExplode, position, Quaternion.identity);
        Destroy(Instantiate(explosionEffect, position, Quaternion.identity), 0.21f);
        // Destroy(gameObject);
    }

    public void AddBullet(GameObject bullet)
    {
        bullet.transform.parent = gameObject.transform;
    }

    public void ReleaseBullet(GameObject bullet)
    {
        var bulletCollider = bullet.GetComponent<PolygonCollider2D>();
        if (!ReferenceEquals(bulletCollider, null))
        {
            bulletCollider.isTrigger = false;
        }
        bullet.transform.parent = null;
    }
}
