using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private int health;
    private float _searchRange = 20f;
    private float _searchTimer = 0f;
    private float _searchCD = 2f;
    private float _attackRange = 3f;
    private float _attackTimer = 0f;
    private float _attackCD = 3f;
    private int _damage = 1;
    private PlayerController _target;
    private Transform _randomPoint;
    private float speed;

    public bool _isAlive => health > 0;
    public EnemyState State { get; private set; } = EnemyState.Idle;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private LayerMask _searchLayer;

    public void Initialize(EnemyStats enemyStats)
    {
        health = enemyStats.Health;
        speed = enemyStats.Speed;
        _agent.speed = speed;
    }

    private void Update()
    {
        _searchTimer += Time.deltaTime;
        if (_searchTimer >= _searchCD)
        {
            ScanForPlayer();
            _searchTimer = 0f;
        }
        switch (State)
        {
            case EnemyState.Idle:
                // Move();
                break;
            case EnemyState.Chase:
                GoTo();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            default:
                return;
        }
    }

    private void GoTo()
    {
        if (_target == null) return;
        _agent.SetDestination(_target.transform.position);
        float distance = Vector3.Distance(transform.position, _target.transform.position);
        if (distance <= _attackRange)
        {
            State = EnemyState.Attack;
        }
    }

    private void Attack()
    {
        _attackTimer += Time.deltaTime;
        if (_attackTimer <= _attackCD) return;
        _attackTimer = 0;
        if (_target == null) return;
        _target.TakeDamage(_damage);
    }

    private void ScanForPlayer()
    {
        _agent.ResetPath();
        Collider[] colliders = Physics.OverlapSphere(transform.position, _searchRange, _searchLayer);
        if (colliders.Length == 0)
        {
            _target = null;
            State = EnemyState.Idle;
            return;
        }

        if (colliders[0].gameObject.TryGetComponent<PlayerController>(out PlayerController player) && player._isAlive)
        {
            _target = player;
            State = EnemyState.Chase;
        }
        else
        {
            _target = null;
            State = EnemyState.Idle;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!_isAlive) return;
        health -= damage;
        if (!_isAlive) DeathProcess();
    }

    private void DeathProcess()
    {
        this.gameObject.SetActive(false);
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

public enum EnemyState
{
    None = 0,
    Idle = 1,
    Chase = 2,
    Attack = 3,
}
