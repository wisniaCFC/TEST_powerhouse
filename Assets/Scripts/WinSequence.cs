using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sequence", menuName = "ScriptableObjects/WinSequence")]
public class WinSequence : ScriptableObject, ISequence
{
    public int[] _rewardsSequence = new int[7];
    public int[] RewardsSequence
    {
        get { return _rewardsSequence; }
        set { _rewardsSequence = value; }
    }
}
