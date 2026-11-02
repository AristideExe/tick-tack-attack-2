using System;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HatScriptableObject hatScriptableObject;

    private void Start()
    {
        if (hatScriptableObject == null) return;
        GameObject hat = Instantiate(hatScriptableObject.prefab, transform.position, transform.rotation);
        hat.transform.localScale = transform.localScale;
        hat.transform.SetParent(transform, true);
    }
}
