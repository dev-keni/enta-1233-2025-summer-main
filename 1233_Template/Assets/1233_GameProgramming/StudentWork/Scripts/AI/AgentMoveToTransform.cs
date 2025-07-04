using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AgentMoveToTransform : AIBulletManager
{
    [SerializeField] private Transform MoveTo;
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private GameObject AgentCharacter;
    [SerializeField] private GameObject AgentWeapon;
    [SerializeField] private GameObject Target;

    private Vector3 AgentLocation;
    private float DetectionRadius = 10.0f;
    private bool PlayerDetected = false;

    private float BulletDelay = 1.5f;
    private float Cooldown = 0f;

    void Update()
    {
        Vector3 pos = Vector3.down;
        AgentLocation = AgentCharacter.transform.position;
        DetectPlayer(AgentLocation, DetectionRadius);
        if (PlayerDetected)
        {
            Cooldown -= Time.deltaTime;
            //Debug.Log(Cooldown);
            Agent.destination = PlayerLocatorSingleton.Instance.transform.position;
            if (Cooldown <= 0f)
            {
                Fire(AgentWeapon.transform);
                AgentWeapon.GetComponent<AudioSource>().Play();
                //Debug.Log("SHOTTED");
                Cooldown = BulletDelay;
            }
        }
        else
        {
            Agent.destination = AgentCharacter.transform.position;
        }
    }
    void DetectPlayer(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.name == "ReplacedCharacter")
            {
                PlayerDetected = true;
            }
            else
            {
                PlayerDetected = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(AgentLocation, DetectionRadius);
    }

}
