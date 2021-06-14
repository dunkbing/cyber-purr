using UnityEngine;
using Random = UnityEngine.Random;

public class Helicopter : Entity
{
    public GameObject soldierPrefab;
    private int _speed;

    public bool RightSide { get; set; }
    private Rigidbody2D _rb;

    private void Awake()
    {
        _speed = Random.Range(6, 12);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (!RightSide)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
        Invoke(nameof(SpawnSoldier), Random.Range(0.3f, 0.5f));
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        if (RightSide)
        {
            _rb.MovePosition(Vector3.right * (Time.fixedDeltaTime * _speed) + transform.position);
            return;
        }
        _rb.MovePosition(Vector3.left * (Time.fixedDeltaTime * _speed) + transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            var explodeObj = other.GetComponent<Entity>();
            explodeObj.Explode();
        }

        if (other.CompareTag("Bound"))
        {
            Destroy(gameObject);
        }
    }

    private void SpawnSoldier()
    {
        var soldier = Instantiate(soldierPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<Soldier>();
        soldier.RightSide = RightSide;
        Global.Instance.gameObjects.Add(soldier.gameObject);
    }
}
