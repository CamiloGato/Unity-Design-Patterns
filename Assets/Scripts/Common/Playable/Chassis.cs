using System.Collections.Generic;
using Common.Addons;
using Common.Configuration;
using UnityEngine;

namespace Common.Playable
{
    public class Chassis : MonoBehaviour
    {
        public Id id;
        
        [SerializeField] private List<Transform> tyresPosition;
        [SerializeField] private List<AddonPositioner> addonPositions;
        
        public List<Transform> TyresPositions => tyresPosition;
        public int TyresAmount => tyresPosition.Count;
        
        public Transform GetPositionFromAddon(AddonType type)
        {
            return addonPositions.Find(addon => addon.type == type)?.position;
        }
        
    }
}