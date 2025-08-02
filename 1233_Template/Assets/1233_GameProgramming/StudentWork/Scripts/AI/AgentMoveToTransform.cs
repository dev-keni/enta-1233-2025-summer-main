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

    private Vector3 _agentLocation;
    private float _detectionRadius = 30.0f;
    private bool _playerDetected = false;

    private float _bulletDelay = 1.5f;
    private float _cooldown = 0f;

    void Awake()
    {
        GameObject foundObject = GameObject.Find("MoveToLocator");
        MoveTo = foundObject.GetComponent<Transform>();
    }

    //
    void Update()
    {
        Vector3 pos = Vector3.down;
        _agentLocation = AgentCharacter.transform.position;
        DetectPlayer(_agentLocation, _detectionRadius);
        if (_playerDetected)
        {
            _cooldown -= Time.deltaTime;
            //Debug.Log(Cooldown);
            Agent.destination = PlayerLocatorSingleton.Instance.transform.position;
            if (_cooldown <= 0f)
            {
                Fire(AgentWeapon.transform);
                AgentWeapon.GetComponent<AudioSource>().Play();
                _cooldown = _bulletDelay;
            }
        }
        else
        {
            Agent.destination = AgentCharacter.transform.position;
        }
    }

    //Detect the player, then turn on chase
    void DetectPlayer(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.name == "ReplacedCharacter")
            {
                _playerDetected = true;
            }
            else
            {
                _playerDetected = false;
            }
        }
    }

    //debug radius
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_agentLocation, _detectionRadius);
    }

}
