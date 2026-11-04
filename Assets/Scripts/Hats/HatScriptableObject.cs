using UnityEngine;

namespace Hats
{
    [CreateAssetMenu(fileName = "Hat", menuName = "Hats/Hat")]
    public class HatScriptableObject : ScriptableObject
    {
        public int id;
        public Sprite sprite;
        public GameObject prefab;
    }
}
