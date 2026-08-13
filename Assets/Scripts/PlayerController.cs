using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private int _health = 5;
    [SerializeField] private int _damage = 5;

    public bool _isAlive => _health > 0;
    public int Health => _health;
    private bool _isRunning;
    private bool _isSatDown;
    private float _cordz;
    private float _cordx;
    private Vector3 _moveVector;


    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _shotRange = 40f;

    private void OnEnable()
    {
        MyInputManager.OnMovePressed += ReadMoveInput;
        MyInputManager.OnSpacePressed += PlayAnimation;
        MyInputManager.OnShiftPressed += ReadShiftInput;
        MyInputManager.OnAttackPressed += ShotWeapon;
    }

    private void OnDisable()
    {
        MyInputManager.OnSpacePressed -= PlayAnimation;
        MyInputManager.OnMovePressed -= ReadMoveInput;
        MyInputManager.OnShiftPressed -= ReadShiftInput;
        MyInputManager.OnAttackPressed -= ShotWeapon;
    }

    private void ReadMoveInput(Vector2 inputVector)
    {
        _cordz = inputVector.y;
        _cordx = inputVector.x;
    }

    private void Move()
    {
        if (_cordz <= 0) _isRunning = false;
        float currentSpeed = _isRunning ? _runSpeed : _walkSpeed;
        _moveVector = transform.right * _cordx + transform.forward * _cordz;
        _moveVector *= currentSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_moveVector + _rigidbody.position);
    }

    public void TakeDamage(int damage)
    {
        if (!_isAlive)
        {
            Debug.Log("Dead");
            return;
        }

        _health -= damage;
        Debug.Log(_health);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        DoAnim();
    }

    private void PlayAnimation()
    {
        Debug.Log("asdkjhdakjhadkj");
    }

    private void ReadShiftInput(bool isPressed)
    {
        if (_cordz >= 0) _isRunning = isPressed;
    }

    private void DoAnim()
    {
        float currentSpeed = _isRunning ? _runSpeed : _walkSpeed;
        if (animator != null)
        {
            // if (Input.GetKeyDown(KeyCode.E) && !_isSatDown)
            // {
            //     _isSatDown = true;
            // }
            // else if (Input.GetKeyDown(KeyCode.E) && _isSatDown)
            // {
            //     _isSatDown = false;
            // }
            // bool IsMoving = _cordx != 0 || _cordz != 0;
            // animator.SetBool("run", IsMoving && _isRunning);
            // animator.SetBool("SitDown", _isSatDown);
            // animator.SetFloat("Speed", _cordz * currentSpeed);
            // animator.SetFloat("Strafe", _cordx);
            animator.SetFloat("Right", _cordx);
            animator.SetFloat("Forward", _cordz);
        }
    }

    private void ShotWeapon(bool isPressed)
    {
        if (!isPressed)
        {
            return;
        }
#if UNITY_EDITOR
        DrawRay();
#endif
        RaycastHit hit;
        if (Physics.Raycast(_shotPoint.position, _shotPoint.forward, out hit, _shotRange))
        {
            // Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.TryGetComponent<EnemyController>(out EnemyController enemy))
            {
                if (!enemy._isAlive) return;
                enemy.TakeDamage(_damage);
            }
        }
    }

#if UNITY_EDITOR
    private void DrawRay()
    {
        Debug.DrawRay(_shotPoint.position, _shotPoint.forward * _shotRange, Color.blue, 3f);
    }
#endif


    //private void Update()
    //{
    //    float moveX = Input.GetAxisRaw(XAXIS);
    //    float moveZ = Input.GetAxisRaw(YAXIS);

    //    _isRunning = Input.GetKey(KeyCode.LeftShift);

    //    _targetDirection = new Vector3(moveX, 0f, moveZ).normalized;

    //    SmoothDirection();
    //    DoAnim();
    //}

    //private void FixedUpdate()
    //{
    //    DoMove();
    //}

    //private void SmoothDirection()
    //{
    //    _currentDirection = Vector3.Lerp(_currentDirection, _targetDirection, Time.deltaTime * _smoothForce);
    //}

    //private void DoMove()
    //{
    //    float currentSpeed = _isRunning ? _runSpeed : _walkSpeed;

    //    if (_currentDirection.z < 0)
    //    {
    //        currentSpeed *= 0.5f;
    //    }

    //    Vector3 targetVelocity = _currentDirection * currentSpeed;

    //    _rigidbody.linearVelocity = targetVelocity;
    //}

    //private void DoAnim()
    //{
    //    float animSpeedMultiplier = _isRunning ? 2f : 1f;

    //    animator.SetFloat("Speed", _currentDirection.x);
    //    animator.SetFloat("Strafe", _currentDirection.z * animSpeedMultiplier);
    //}
}