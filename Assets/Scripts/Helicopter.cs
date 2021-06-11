using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public int speed = 10;

    public bool RightSide { get; set; }
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (!RightSide)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void Update()
    {
        if (RightSide)
        {
            _rb.MovePosition(Vector3.right * (Time.deltaTime * speed) + transform.position);
            return;
        }
        _rb.MovePosition(Vector3.left * (Time.deltaTime * speed) + transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }
}
