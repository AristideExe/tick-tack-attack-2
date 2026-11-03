using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HatUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image hatImage;
    
    [Header("Settings")]
    [SerializeField] private HatScriptableObject hatData;
    
    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    private void Start()
    {
        hatImage.sprite = hatData.sprite;
    }

    public void SetHat()
    {
        PlayerCustomization.Instance.SetHat(hatData);
    }

    public void Update()
    {
        if (PlayerCustomization.Instance.HatData == hatData)
        {
            _buttonImage.color = Color.dodgerBlue;
        }
        else
        {
            _buttonImage.color = Color.white;
        }
    }
}
