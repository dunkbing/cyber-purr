using UnityEngine;

public class Cat : Entity, ISpawn
{
    public GameObject catExplode;
    public GameObject explosionEffect;

    public void Spawn()
    {

    }

    private void Start()
    {
        OnExplode += (TriggerAnimation);
    }

    private void TriggerAnimation()
    {
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
