using UnityEngine;
using Random = UnityEngine.Random;

public class Helicopter : Entity, ISpawn
{
    public GameObject soldierPrefab;
    public GameObject explosionEffect;
    public GameObject fragments;
    private int _speed;
    private bool? _rightSide;
    private Rigidbody2D _rb;

    public void Spawn()
    {
        _rightSide ??= Random.Range(0, 2) == 0;
        var randomPos = (bool) _rightSide ? new Vector3(-11, Random.Range(1, 4)) : new Vector3(11, Random.Range(1, 4));
        transform.position = randomPos;
        _speed = Random.Range(3, 7);
        if ((bool) !_rightSide)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        Invoke(nameof(SpawnSoldier), Random.Range(0.7f, 1.6f));
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        OnExplode += () =>
        {
            var position = transform.position;
            Destroy(Instantiate(fragments, position, Quaternion.identity), 3f);
            Destroy(Instantiate(explosionEffect, position, Quaternion.identity), 0.5f);
        };
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        if (_rightSide != null && (bool) _rightSide)
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
            Explode();
        }
    }

    private void SpawnSoldier()
    {
        if (gameObject == null || !gameObject.activeSelf) return;
        Pool.Instance.Spawn("Soldier", transform.position, transform.rotation, (go) =>
        {
            var soldier = go.GetComponent<Soldier>();
            if (_rightSide != null) soldier.RightSide = (bool) _rightSide;
        });
    }

}
