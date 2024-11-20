using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int CurrentExp { get; private set; }
    private int needLevelupExp;

    public int PlayerLevel { get; private set; }

    public Player()
    {
        PlayerLevel = 1;
        CurrentExp = 0;
    }


}
