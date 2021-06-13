using UnityEngine;

public class Cat : Entity
{
    private void Start()
    {
        OnExplode += (TriggerAnimation);
    }

    private void TriggerAnimation()
    {
        Debug.Log("cat explode animation");
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
