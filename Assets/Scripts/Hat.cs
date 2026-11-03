using System;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HatsScriptableObject hatList;
    
    [Header("Settings")]
    [SerializeField] private bool randomHat;
    [SerializeField] private float chanceOfHat;
    
    private HatScriptableObject _hatData;

    private void Start()
    {
        if (randomHat && UnityEngine.Random.value * 100 < chanceOfHat)
        {
            _hatData = hatList.hats[UnityEngine.Random.Range(0, hatList.hats.Length)];
        }
        else
        {
            _hatData = PlayerCustomization.Instance.HatData;
        }
        if (_hatData == null) return;
        
        GameObject hat = Instantiate(_hatData.prefab, transform.position, transform.rotation);
        hat.layer = gameObject.layer;
        hat.transform.localScale = transform.localScale;
        hat.transform.SetParent(transform, true);
    }
}
