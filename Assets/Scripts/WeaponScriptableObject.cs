using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public float damage;
    public float delay;
    public GameObject prefab;
    public Sprite sprite;
}
