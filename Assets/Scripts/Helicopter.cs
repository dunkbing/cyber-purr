using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Helicopter : MonoBehaviour
{
    public GameObject soldierPrefab;
    private int _speed;
    private bool _solderSpawned;

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
    }

    private void FixedUpdate()
    {
        if (RightSide)
        {
            _rb.MovePosition(Vector3.right * (Time.fixedDeltaTime * _speed) + transform.position);
            return;
        }
        _rb.MovePosition(Vector3.left * (Time.fixedDeltaTime * _speed) + transform.position);

        if (_solderSpawned) return;
        if (Random.Range(1, 10) < 5)
        {
            SpawnSoldier();
        }
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

    private void SpawnSoldier()
    {
        var soldier = Instantiate(soldierPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<Soldier>();
        soldier.RightSide = RightSide;
        _solderSpawned = true;
    }
}
