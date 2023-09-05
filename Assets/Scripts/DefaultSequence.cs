using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSequence : ISequence
{
    public int[] RewardsSequence { get; set; }

    public DefaultSequence()
    {
        RewardsSequence = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
    }
}
