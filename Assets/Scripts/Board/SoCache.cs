using System.Collections.Generic;
using UnityEngine;

public class SoCache
{
    private static readonly Dictionary<string, ScriptableObject> _cache = new Dictionary<string, ScriptableObject>();
    
    public static T Get<T>(string resourcePath) where T : ScriptableObject
    {
        if (string.IsNullOrEmpty(resourcePath)) return null;

        if (_cache.TryGetValue(resourcePath, out var so))
            return so as T;

        var loaded = Resources.Load<T>(resourcePath);
        if (!loaded)
        {
            Debug.LogError($"[SoCache] Not found: Resources/{resourcePath}");
            return null;
        }

        _cache[resourcePath] = loaded;
        return loaded;
    }
}