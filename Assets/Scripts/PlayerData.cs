using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int _bestScore = 0;

    public int BestScore
    {
        get { return _bestScore; }
        set
        {
            if (value > _bestScore)
                _bestScore = value;

        }
    }
}
