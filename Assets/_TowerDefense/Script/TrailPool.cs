using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Pool;

namespace V.TowerDefense
{
    public class TrailPool : MonoBehaviour
    {
        public static TrailPool I {get; private set;} 

        [Expandable]public ArcherTrailSO TrailConfig;

        private ObjectPool<TrailRenderer> _trailPool;

        private void Awake() 
        {
            if(I != null)
            {
                Debug.LogWarning("More than one Trail Pool Instance");
            }
            I = this;
        }

        private void Start() 
        {
            _trailPool = new ObjectPool<TrailRenderer>(TrailConfig.CreateTrail);
        }

        public TrailRenderer GetTrailFromPool(Vector3 startPoint)
        {
            TrailRenderer newTrail = _trailPool.Get();
            newTrail.gameObject.SetActive(true);
            newTrail.transform.position = startPoint;

            return newTrail;
        }

        public void ReleaseTrail(TrailRenderer trail)
        {
            trail.emitting = false;
            trail.gameObject.SetActive(false);
            _trailPool.Release(trail);
        }
    }
}
