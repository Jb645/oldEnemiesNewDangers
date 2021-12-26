using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform playerToChase;
    public NavMeshAgent navMesh;

    public float distance;

    private void FixedUpdate()
    {
        navMesh.SetDestination(playerToChase.position);
        distance = Vector3.Distance(navMesh.transform.position, playerToChase.position);

        if (distance <= 1.2f)
        {
            //Debug.Log("Game over by basic enemy", gameObject);
        }
    }
}