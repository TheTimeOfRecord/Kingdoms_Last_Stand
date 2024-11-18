using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Outline outline;
    [SerializeField] private TrailRenderer trailRenderer;


    private void MakeTrialRenderer()
    {
        if (trailRenderer != null)
        {
            // TrailRenderer 설정 변경
            trailRenderer.startColor = Color.red;
            trailRenderer.endColor = Color.yellow;
            trailRenderer.time = 2.0f;
            trailRenderer.startWidth = 0.5f;
            trailRenderer.endWidth = 0.1f;
        }
    }

    private void InitProjectile(Transform target, ProjectileSO projectileSO, float damage)
    {
        Debug.Log("위치로 발사");
    }
}
