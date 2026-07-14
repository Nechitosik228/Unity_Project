using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 5f;

    private bool _isRunning;
    private float _cordz;
    private float _cordx;
    private Vector3 _moveVector;

    private void OnEnable()
    {
        MyInputManager.OnMovePressed += ReadMoveInput;
        MyInputManager.OnSpacePressed += PlayAnimation;
    }

    private void OnDisable()
    {
        MyInputManager.OnSpacePressed -= PlayAnimation;
        MyInputManager.OnMovePressed -= ReadMoveInput;
    }

    private void ReadMoveInput(Vector2 inputVector)
    {
        _cordz = inputVector.y;
        _cordx = inputVector.x;
    }

    private void Move()
    {
        _moveVector = transform.right * _cordx + transform.forward * _cordz;
        _moveVector *= _walkSpeed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_moveVector + _rigidbody.position);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayAnimation()
    {
        Debug.Log("asdkjhdakjhadkj");
    }




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