using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Camera _cam;
    private GameObject _currentBullet;
    private readonly Vector3 _spawnPos = new Vector3(0, -3.26f, 0);
    private const float BulletForce = 15f;
    private Cat _cat;

    private Vector3 _mousePos;
    private float _reloadTime = 0.5f;

    private void Awake()
    {
        _cat = GetComponent<Cat>();
        _currentBullet = Instantiate(bulletPrefab, _spawnPos, Quaternion.identity);
        _cam = Camera.main;
    }

    void Start()
    {
        _cat.AddBullet(_currentBullet);
    }

    void Update()
    {
        if (Global.Paused)
        {
            return;
        }
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        // handle shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        RotateBullet();
    }

    private void RotateBullet()
    {
        if (ReferenceEquals(_currentBullet, null)) return;
        var lookDir = _mousePos - gameObject.transform.position;
        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        if (angle < -90 && angle > -180)
        {
            angle = -90;
        } else if (angle > -270 && angle < -180)
        {
            angle = -270;
        }
        _currentBullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Shoot()
    {
        if (ReferenceEquals(_currentBullet, null)) return;
        Rigidbody2D rb = _currentBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_currentBullet.transform.up * BulletForce, ForceMode2D.Impulse);
        _cat.ReleaseBullet(_currentBullet);
        _currentBullet = null;
        Invoke(nameof(Reload), _reloadTime);
    }

    private void Reload()
    {
        // create new bullet and move it to cat's child
        _currentBullet = Instantiate(bulletPrefab, _spawnPos, Quaternion.identity);
        _cat.AddBullet(_currentBullet);
    }

}
