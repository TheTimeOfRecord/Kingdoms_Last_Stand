using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowerRight : MonoBehaviour
{
    [SerializeField] private UISlotTowerRight testSlot;
    [SerializeField] private Tower testTower;
    [SerializeField] private Transform slotParent;
    // Start is called before the first frame update
    void Start()
    {
        UISlotTowerRight slot = Instantiate(testSlot, slotParent);
        slot.InitData(testTower);
        slot.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
