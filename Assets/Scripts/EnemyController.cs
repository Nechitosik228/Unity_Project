using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health;
    private float speed;

    public void Initialize(EnemyStats enemyStats)
    {
        health = enemyStats.Health;
        speed = enemyStats.Speed;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
