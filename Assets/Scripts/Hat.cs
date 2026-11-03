using System;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HatsScriptableObject hatList;
    
    [Header("Settings")]
    [SerializeField] private bool randomHat;
    [SerializeField] private float chanceOfHat;
    
    private GameObject hat;
    
    private void Start()
    {
        HatScriptableObject hatData;
        if (randomHat && UnityEngine.Random.value * 100 < chanceOfHat)
        {
            hatData = hatList.hats[UnityEngine.Random.Range(0, hatList.hats.Length)];
        }
        else
        {
            hatData = PlayerCustomization.Instance.HatData;
        }
        if (hatData == null) return;
        SetHat(hatData);
    }

    public void SetHat(HatScriptableObject hatData)
    {
        if (hat != null) Destroy(hat);
        GameObject instance = Instantiate(hatData.prefab, transform.position, transform.rotation);
        instance.layer = gameObject.layer;
        instance.transform.localScale = transform.localScale;
        instance.transform.SetParent(transform, true);
        hat = instance;
    }
}
