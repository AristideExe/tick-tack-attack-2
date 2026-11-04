using Hats;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HatsUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private GameObject hatButtonPrefab;
        [SerializeField] private HatsScriptableObject hatList;

        public void Start()
        {
            for (int i = 0; i < hatList.hats.Length; i++)
            {
                GameObject hatButton = Instantiate(hatButtonPrefab, gridLayoutGroup.transform, true);
                hatButton.GetComponent<HatUI>().HatData = hatList.hats[i];
            }
        }
    }
}
