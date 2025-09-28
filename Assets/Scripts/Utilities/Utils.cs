using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    private static readonly NormalItem.eNormalType[] _allTypes =
        (NormalItem.eNormalType[])Enum.GetValues(typeof(NormalItem.eNormalType));
    
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }
    
    public static NormalItem.eNormalType GetRandomNormalTypeExcept(IList<NormalItem.eNormalType> except)
    {
        if (except == null || except.Count == 0)
            return GetRandomNormalType();

        var candidates = new List<NormalItem.eNormalType>(_allTypes.Length);
        for (int i = 0; i < _allTypes.Length; i++)
        {
            var t = _allTypes[i];
            bool skip = false;
            for (int j = 0; j < except.Count; j++)
            {
                if (except[j] == t) { skip = true; break; }
            }
            if (!skip) candidates.Add(t);
        }

        return candidates[URandom.Range(0, candidates.Count)];
    }
}
