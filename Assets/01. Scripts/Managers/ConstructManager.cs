using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructManager : SingletonDestroyable<ConstructManager>
{
    public Tower SelectedTower { get; private set; }
    public ConstructPoint NowPoint { get; private set; }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && CheckConstructable())
        {
            //TODO 설치
            Debug.Log("설치 시도");
            NowPoint.ConstructTower(SelectedTower);
        }
    }

    public void SetConstructPoint(ConstructPoint point)
    {
        if (point != null)
        {
            NowPoint = point;
        }
        else
        {
            NowPoint = null;
        }
    }

    public void SelectTower(Tower selectedTower)
    {
        SelectedTower = selectedTower;
    }

    public bool CheckConstructable()
    {
        if(SelectedTower != null && NowPoint!= null)
        {
            if(NowPoint.IsTowerConstructed == false)
            {
                return true;
            }
        }

        return false;
    }

    public void TestButton(Tower tower)
    {
        SelectedTower = tower;
    }
}
