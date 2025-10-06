using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public Transform player;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float attackDistance = 1.5f;
    public float chaseDistance = 5f;

    private enum State { Patrol, Chase, Attack }
    private State currentState = State.Patrol;
    private Vector3 patrolPoint;

    void Start()
    {
        patrolPoint = transform.position + new Vector3(3f, 0, 3f);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Переключение состояний
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                if (distance < chaseDistance)
                    currentState = State.Chase;
                break;

            case State.Chase:
                Chase();
                if (distance < attackDistance)
                    currentState = State.Attack;
                else if (distance > chaseDistance)
                    currentState = State.Patrol;
                break;

            case State.Attack:
                Attack();
                if (distance > attackDistance)
                    currentState = State.Chase;
                break;
        }
    }

    void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint, patrolSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, patrolPoint) < 0.5f)
            patrolPoint = transform.position + new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    void Attack()
    {
        Debug.Log("Attack!");
    }
}
