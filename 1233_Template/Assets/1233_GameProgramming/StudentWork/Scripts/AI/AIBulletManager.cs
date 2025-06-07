using MyCharacterInput;
using UnityEngine;

public class AIBulletManager : BaseBulletManager
{
    [SerializeField] private Transform BulletSpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //add way to trigger shooting
        
    }

    private void Fire()
    {
        SpawnPhysicsBullet(BulletSpawnPoint);
    }
}
