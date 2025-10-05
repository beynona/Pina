using UnityEngine;

namespace Events
{
    public class DamageText : MonoBehaviour
    {
        public void Erase()
        {
            Destroy(gameObject);
        }
    }
}