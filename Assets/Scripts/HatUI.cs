using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HatUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image hatImage;
    
    public HatScriptableObject HatData;
    
    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    private void Start()
    {
        hatImage.sprite = HatData.sprite;
    }

    public void SetHat()
    {
        PlayerCustomization.Instance.SetHat(HatData);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponentInChildren<Hat>().SetHat(HatData);
    }

    public void Update()
    {
        if (PlayerCustomization.Instance.HatData == HatData)
        {
            _buttonImage.color = Color.dodgerBlue;
        }
        else
        {
            _buttonImage.color = Color.white;
        }
    }
}
