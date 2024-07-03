using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace V.TowerDefense
{
    [CreateAssetMenu(fileName = "Trail Config", menuName = "Tower Defense/Archer Trail Config", order = 4)]
    public class ArcherTrailSO : ScriptableObject
    {
        [ShowAssetPreview]
        [SerializeField] private Material _material;
        [SerializeField] private AnimationCurve _widthCurve;
        [SerializeField] private float _minVertexDistance = .1f; // 形成線之間的兩點距離
        [SerializeField] private Gradient _trailGradient;
        [SerializeField] private bool _isEmitting = false;
        [field : SerializeField] public float Duration {get; private set;} = .5f;

        [field : SerializeField] public float MissDistance {get; private set;} = 20f;
        [field : SerializeField] public float SimulationSpeed {get; private set;} = 100f; // 移動速度

        #region Instantiate Trail Renderer 
        /// <summary>
        /// Create a new trail
        /// </summary>
        /// <returns></returns>
        public TrailRenderer CreateTrail()
        {
            GameObject newTrailGO = new GameObject("Bullet Trail");
            TrailRenderer trail = newTrailGO.AddComponent<TrailRenderer>();

            trail = SetupTrailConfig(trail);

            return trail;
        }

        private TrailRenderer SetupTrailConfig(TrailRenderer t)
        {
            t.material = _material;
            t.widthCurve = _widthCurve;
            t.time = Duration;
            t.minVertexDistance = _minVertexDistance;
            t.colorGradient = _trailGradient;
            t.emitting = _isEmitting;

            t.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            return t;
        }
        #endregion
    }
}
