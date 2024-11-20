using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    public ProjectileSO projectileData;
    //[SerializeField] private float shootSpeed --> Init함수 projectileData.shootSpeed;
    //[SerializeField] private Vector2 target; Vector2 ShootDirection = ((Vector2)target - transform.position).nomalized
    //[SerializeField] private float attackRate = 0.1f; --> Init함수 TowerSO.attackRate

    [SerializeField] private UnityEvent towerShoot;

    private IObjectPool<Projectile> objectPool;

    private void Awake()
    {
        objectPool = ObjectPoolManager.Instance.GetProjectilePool();
    }

    public void UpdateAttack(Vector2 targetPosition, List<AttackTypeStat> typeStats)
    {

    }

    private void Shoot()//TODO -> projectileObject 이사
    {
        if (objectPool != null) return;

        Projectile projectileObject = objectPool.Get();

        if (projectileObject == null) return;

        Vector2 direction = Vector2.zero; //임시 오류방지용
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        projectileObject.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0,0,angle));

        //TODO : Sprite-> Init한거 함수로 한꺼번에 덮어쓰기.
        //projectileObject.GetComponent<Rigidbody2D>().AddForce(projectileObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);

        projectileObject.Deactivate();

        //Inin으로 초기값 받아와야함. Deactivate-> sprite 다 벗기기
        //nextTimeToShoot = Time.time + cooldownWindow;

        towerShoot.Invoke();
    }
}
