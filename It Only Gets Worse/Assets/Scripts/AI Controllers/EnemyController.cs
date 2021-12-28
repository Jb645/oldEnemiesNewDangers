using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform playerToChase;
    public NavMeshAgent navMesh;

    public float distance;
    public bool isMoving = true;

    private void FixedUpdate()
    {
        navMesh.SetDestination(playerToChase.position);
        distance = Vector3.Distance(navMesh.transform.position, playerToChase.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isMoving = false;
        }
    }
}