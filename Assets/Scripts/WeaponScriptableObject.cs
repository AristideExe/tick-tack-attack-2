using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public float damage;
    public float delay;
    public ShootingDelay shootingDelay;
    public ShootingType shootingType;
    public int magazineSize;
    public int burstCount;
    public int spreadCount;
    public float spreadAngle;
    public float recoil;
    public GameObject prefab;
    public Sprite sprite;
}
