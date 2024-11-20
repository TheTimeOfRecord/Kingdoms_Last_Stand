using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

//TODO : �ڷ�ƾ ����
public class Projectile : MonoBehaviour
{
    private ProjectileSO projectileData = null;
    private TrailRenderer trailRenderer;
    private Outline outline;
    private Sprite projectileSprite;

    private void Awake()
    {
        outline = GetComponent<Outline>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    //�ӽ�
    private void MakeTrialRenderer()
    {
        if (trailRenderer != null)
        {
            // TrailRenderer ���� ����
            trailRenderer.startColor = Color.red;
            trailRenderer.endColor = Color.yellow;
            trailRenderer.time = 2.0f;
            trailRenderer.startWidth = 0.5f;
            trailRenderer.endWidth = 0.1f;
        }
    }

    public void ShootProjectile(Vector3 position, AttributeType type, float damage, Color color)
    {
        InitProjectile(color);
    }

    private void InitProjectile(Color color)
    {
        if (!projectileData)
        {
            outline.effectColor = color;
            trailRenderer.startColor = color;
            trailRenderer.endColor = Color.white;
            projectileSprite = projectileData.projectileSprite;
        }
    }

    [SerializeField] private float timeoutDelay = 3f;

    private IObjectPool<Projectile> objectPool;

    public IObjectPool<Projectile> ObjectPool { set => objectPool = value; }

    public void Deactivate()
    {
        //StartCoroutine(DeactivateRoutine(timeoutDelay));
        objectPool.Release(this);
    }

    private void SomeMethod()
    {
        //�ڷ�ƾ ��ü��... 
    }
    /* �ڷ�ƾ ��� X
    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = Vector2.zero;
        rBody.angularVelocity = 0f;

        objectPool.Release(this);
    }
    */
}
