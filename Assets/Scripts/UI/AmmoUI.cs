using TMPro;
using UnityEngine;
using Weapons;

namespace UI
{
    public class AmmoUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI _ammoText;
        [SerializeField] private Weapon _weapon;
    
        private void Update()
        {
            _ammoText.text = _weapon.Magazine + " / " + _weapon.Ammo;
        }
    }
}
