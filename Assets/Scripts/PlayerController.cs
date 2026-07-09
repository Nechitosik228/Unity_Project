using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _smoothForce = 8f;

    private const string XAXIS = "Horizontal";
    private const string YAXIS = "Vertical";

    private Vector3 _currentDirection;
    private Vector3 _targetDirection;
    private bool _isRunning;

    private void Update()
    {
        float moveX = Input.GetAxisRaw(XAXIS);
        float moveZ = Input.GetAxisRaw(YAXIS);

        _isRunning = Input.GetKey(KeyCode.LeftShift);

        _targetDirection = new Vector3(moveX, 0f, moveZ).normalized;

        SmoothDirection();
        DoAnim();
    }

    private void FixedUpdate()
    {
        DoMove();
    }

    private void SmoothDirection()
    {
        _currentDirection = Vector3.Lerp(_currentDirection, _targetDirection, Time.deltaTime * _smoothForce);
    }

    private void DoMove()
    {
        float currentSpeed = _isRunning ? _runSpeed : _walkSpeed;

        if (_currentDirection.z < 0)
        {
            currentSpeed *= 0.5f;
        }

        Vector3 targetVelocity = _currentDirection * currentSpeed;

        _rigidbody.linearVelocity = targetVelocity;
    }

    private void DoAnim()
    {
        float animSpeedMultiplier = _isRunning ? 2f : 1f;

        animator.SetFloat("Speed", _currentDirection.x);
        animator.SetFloat("Strafe", _currentDirection.z * animSpeedMultiplier);
    }
}