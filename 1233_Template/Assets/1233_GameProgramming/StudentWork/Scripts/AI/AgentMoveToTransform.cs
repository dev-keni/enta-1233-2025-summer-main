using UnityEngine;
using UnityEngine.AI;

public class AgentMoveToTransform : MonoBehaviour
{
    [SerializeField] private Transform MoveTo;
    [SerializeField] private NavMeshAgent Agent;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.down;
        Agent.destination = PlayerLocatorSingleton.Instance.transform.position;
    }
}
