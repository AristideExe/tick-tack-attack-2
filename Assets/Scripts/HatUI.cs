using UnityEngine;
using UnityEngine.UI;

public class HatUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image hatImage;
    
    [Header("Settings")]
    [SerializeField] private HatScriptableObject hatData;
    
    private void Start()
    {
        hatImage.sprite = hatData.sprite;
    }

    public void SetHat()
    {
        PlayerCustomization.Instance.SetHat(hatData);
    }
}
