using UnityEngine;
using Random = UnityEngine.Random;

public class Helicopter : Entity
{
    public GameObject soldierPrefab;
    public GameObject explosionEffect;
    public GameObject fragments;
    private int _speed;

    public bool RightSide { get; set; }
    private Rigidbody2D _rb;

    private void Awake()
    {
        _speed = Random.Range(3, 7);
    }

    private void Start()
    {
        OnExplode += () =>
        {
            var position = transform.position;
            Destroy(Instantiate(fragments, position, Quaternion.identity), 3f);
            Destroy(Instantiate(explosionEffect, position, Quaternion.identity), 0.21f);
        };
        _rb = GetComponent<Rigidbody2D>();
        if (!RightSide)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
        Invoke(nameof(SpawnSoldier), Random.Range(0.7f, 1.6f));
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
