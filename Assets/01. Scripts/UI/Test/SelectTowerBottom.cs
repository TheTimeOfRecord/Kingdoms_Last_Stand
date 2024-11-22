using UnityEngine;

public class SelectTowerBottom : MonoBehaviour
{
    [SerializeField] private UISlotTowerBottom slotBottom;
    private Tower selectedTower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetTowerInfo2D();
        }
    }

    void GetTowerInfo2D()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            Tower tower = hit.collider.GetComponent<Tower>();
            if (tower != null)
            {
                selectedTower = tower;
                slotBottom.InitData(selectedTower);
            }
        }
    }
}
