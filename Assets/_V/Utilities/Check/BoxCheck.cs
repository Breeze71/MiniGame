using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V.TowerDefense
{
    public class BoxCheck : MonoBehaviour, ICheck
    {
        [SerializeField] private LayerMask CheckMask;
        [SerializeField] private float width = 0.1f;
        [SerializeField] private float height = 0.1f;

        public bool Check()
        {                                                                               // angles
            return Physics2D.OverlapBox(transform.position, new Vector2(width , height) , 0 ,CheckMask);
        }

        public bool Check(int _direction, float _distance, LayerMask _checkLayer)
        {
            return Physics2D.OverlapBox(transform.position, new Vector2(_distance , _distance) , 0 , _checkLayer);
        }

        private void OnDrawGizmos()
        {
            if(transform == null)
            {
                return;
            }
            
            Gizmos.color = Color.green;

            Gizmos.DrawWireCube(transform.position , new Vector3(width , height , 1));
        }
        
    }
}
