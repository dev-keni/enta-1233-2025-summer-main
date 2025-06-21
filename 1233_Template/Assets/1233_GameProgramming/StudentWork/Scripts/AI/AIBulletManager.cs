using MyCharacterInput;
using UnityEngine.AI;
using UnityEngine;

public class AIBulletManager : BaseBulletManager
{
    private Transform PointProjectile;
    protected void Fire(Transform AimDirection)
    {
        PointProjectile = AimDirection;
        SpawnPhysicsBullet(PointProjectile);
    }
}
