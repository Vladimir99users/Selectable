using UnityEngine;

namespace Generate
{
    public class SpawmPointer : MonoBehaviour
    {
       private Collider _collider => GetComponent<BoxCollider>();
       public Vector3 BoundsMin => _collider.bounds.min;
       public Vector3 BoundsMax => _collider.bounds.max;

       public bool IsActive
       {
         get 
         {
            return _collider.enabled;
         }
         set
         {
            _collider.enabled = value;
         }
       }
    }

}