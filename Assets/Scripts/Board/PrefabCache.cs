using System.Collections.Generic;
using UnityEngine;

public static class PrefabCache
{
    private static readonly Dictionary<string, GameObject> _cache = new Dictionary<string, GameObject>();

    public static GameObject Get(string resourcePath)
    {
        if (string.IsNullOrEmpty(resourcePath)) return null;

        if (_cache.TryGetValue(resourcePath, out var prefab))
            return prefab;

        prefab = Resources.Load<GameObject>(resourcePath);
        if (!prefab)
        {
            Debug.LogError($"[PrefabCache] Missing prefab at Resources path: {resourcePath}");
            return null;
        }

        _cache[resourcePath] = prefab;
        return prefab;
    }
}