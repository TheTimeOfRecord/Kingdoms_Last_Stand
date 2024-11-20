using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructPoint : MonoBehaviour
{
    public bool IsTowerConstructed { get; private set; }
    public Transform constructPosition;
    public Tower ConstructedTower { get; private set; }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
        ConstructManager.Instance.SetConstructPoint(this);
    }

    private void OnMouseExit()
    {
        Debug.Log("Exit");
        ConstructManager.Instance.SetConstructPoint(null);
    }

    public void ConstructTower(Tower tower)
    {
        ConstructedTower = tower;
        IsTowerConstructed = true;
        Instantiate(tower.gameObject, constructPosition);
    }

    public void DestroyTower()
    {
        ConstructedTower = null;
        IsTowerConstructed = false;
    }
}
