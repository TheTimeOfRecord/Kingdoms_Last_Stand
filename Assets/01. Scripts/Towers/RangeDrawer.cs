using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDrawer : MonoBehaviour
{
    private float radius;
    private int segments = 100;
    private LineRenderer lineRenderer;
    private Tower tower;
    private bool isDrawing = false;

    private void Awake()
    {
        tower = GetComponent<Tower>();
    }
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = segments + 1;
        lineRenderer.loop = true;
        lineRenderer.enabled = false;
        int index = tower.typeListData.AttackLists.Count-1;
        lineRenderer.startColor = tower.typeListData.AttackLists[index].typeColor;
        lineRenderer.endColor = tower.typeListData.AttackLists[index].typeColor;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        radius = tower.towerData.attackRange;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isDrawing = true;
            lineRenderer.enabled = true;
            DrawCircle(radius);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            isDrawing = false;
            lineRenderer.enabled = false;
        }
    }

    private void DrawCircle(float radius)
    {
        float angle = 0f;
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(angle) * radius + transform.position.x;
            float y = Mathf.Sin(angle) * radius + transform.position.y;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0f));
            angle += 2 * Mathf.PI / segments;
        }
    }
}
