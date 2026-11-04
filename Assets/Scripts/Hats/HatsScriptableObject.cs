using UnityEngine;

namespace Hats
{
    [CreateAssetMenu(fileName = "Hats", menuName = "Hats/Hats")]
    public class HatsScriptableObject : ScriptableObject
    {
        public HatScriptableObject[] hats;
    }
}
