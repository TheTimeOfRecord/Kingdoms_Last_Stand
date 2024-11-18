using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //[SerializeField] private List<TowerAttack> attackList = new List<TowerAttack>;
    [SerializeField] private TowerSO towerData;
    [SerializeField] private Transform target;

    private void AddAttack(ProjectileSO projectileSO)
    {
        //attackList.Add(new TowerAttack(projectileSO));
    }
}
