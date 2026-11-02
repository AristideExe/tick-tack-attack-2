using System;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HatsScriptableObject hatList;
    [SerializeField] private HatScriptableObject hatData;
    
    [Header("Settings")]
    [SerializeField] private bool randomHat;
    [SerializeField] private float chanceOfHat;
    

    private void Start()
    {
        if (randomHat && UnityEngine.Random.value * 100 < chanceOfHat)
        {
            hatData = hatList.hats[UnityEngine.Random.Range(0, hatList.hats.Length)];
        }
        if (hatData == null) return;
        
        GameObject hat = Instantiate(hatData.prefab, transform.position, transform.rotation);
        hat.layer = gameObject.layer;
        hat.transform.localScale = transform.localScale;
        hat.transform.SetParent(transform, true);
    }
}
