using UnityEngine;

[CreateAssetMenu(fileName = "ItemSkinFish", menuName = "Game/Item Skin/Fish")]
public class ItemSkinFish : ScriptableObject
{
    [SerializeField] private Sprite[] _sprites;

    public Sprite GetSprite(NormalItem.eNormalType type)
    {
        return _sprites[(int)type];
    }
}