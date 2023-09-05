using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SequencesManager
{
    private static ISequence _sequence;
    
    public static ISequence Sequence
    {
        get { return _sequence; }
        set { _sequence = value; }
    }
}
