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
}
