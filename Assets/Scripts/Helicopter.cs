using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public int speed = 10;

    public bool RightSide { get; set; }

    private void Start()
    {
        if (!RightSide)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            speed *= -1;
        }
    }

    private void Update()
    {
        if (RightSide)
        {
            gameObject.transform.Translate(Vector3.right * (Time.deltaTime * speed));
            return;
        }
        gameObject.transform.Translate(Vector3.left * (Time.deltaTime * speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bullet")) return;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
