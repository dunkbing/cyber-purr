using UnityEngine;

public class Soldier : Entity
{
    private Animator _animator;
    private Rigidbody2D _rb;

    private bool _moving;

    private float _speed;

    private static readonly int OnGround = Animator.StringToHash("OnGround");

    public bool RightSide { get; set; }

    private void Awake()
    {
        _speed = Random.Range(1.5f, 5f);
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        OnExplode += (() =>
        {
            // TODO: add explosion anim later
            Debug.Log("soldier exploded");
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator.SetBool(OnGround, false);
        if (!RightSide)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    void FixedUpdate()
    {
        if (_moving)
        {
            MoveForward();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool(OnGround, true);
            _moving = true;
            _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        } else if (other.gameObject.CompareTag("Cat") || other.gameObject.CompareTag("Soldier"))
        {
            var entity = other.gameObject.GetComponent<Entity>();
            entity.Explode();
            GameObject.Find("Global").GetComponent<MenuHandler>().Pause();
            this.Explode();
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
            Invoke(nameof(Explode), .5f);
            MenuHandler.Instance.IncreaseScore();
        }
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

}
