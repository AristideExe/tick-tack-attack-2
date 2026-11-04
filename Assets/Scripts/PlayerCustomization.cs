using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    private static PlayerCustomization _instance;
    public static PlayerCustomization Instance => _instance;

    [SerializeField] private HatScriptableObject hatData;
    public HatScriptableObject HatData => hatData;

    private void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetHat(HatScriptableObject hd)
    {
        hatData = hd;
    }
}
