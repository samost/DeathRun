using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "TagsWeapon", order = 0)]
    public class WeaponsTagsList : ScriptableObject
    {
        public List<string> weaponsTags;
    }
}