using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructPoint : MonoBehaviour
{
    public bool IsTowerConstructed { get; private set; }
    public Transform constructPosition;
    public Tower ConstructedTower { get; private set; }

    [SerializeField] private GameObject selectImage;

    private void OnMouseEnter()
    {
        selectImage.SetActive(true);
        ConstructManager.Instance.SetConstructPoint(this);
    }

    private void OnMouseExit()
    {
        selectImage.SetActive(false);
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
