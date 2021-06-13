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
        bullet.transform.parent = null;
    }
}
