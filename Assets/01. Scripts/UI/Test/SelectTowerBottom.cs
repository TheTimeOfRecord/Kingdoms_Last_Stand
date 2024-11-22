using UnityEngine;

public class SelectTowerBottom : MonoBehaviour
{
    [SerializeField] private UISlotTowerBottom testSlot;
    [SerializeField] private Tower testTower;
    // Start is called before the first frame update
    void Start()
    {
        testSlot.InitData(testTower);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
