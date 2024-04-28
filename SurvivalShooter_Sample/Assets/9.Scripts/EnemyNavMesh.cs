using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public Transform Target;
    protected NavMeshAgent m_LinkNavMesh = null;

    void Start()
    {
        m_LinkNavMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        m_LinkNavMesh?.SetDestination( Target.position );
    }
}
