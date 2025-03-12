#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Lesson_14
{
    public class EffectSystem : MonoBehaviour
    {

        [SerializeField] private HitEffectChooser[] _effects;

        protected Dictionary<Collider, HitEffectChooser> _objectEffects = new();

        public IEnumerable<HitEffectChooser> CharactersEffects => _objectEffects.Values;

        /// <summary>
        /// Editor only method
        /// </summary>
        [ContextMenu("Find Effects")]
        private void FindEffects()
        {
#if UNITY_EDITOR
            _effects = FindObjectsOfType<HitEffectChooser>();
            EditorUtility.SetDirty(this);
#endif
        }

        protected virtual void Awake()
        {
            for (int i = 0; i < _effects.Length; ++i)
            {
                HitEffectChooser effect = _effects[i];
                _objectEffects.Add(effect.CharacterController, effect);
            }
        }

        public virtual bool GetEffects(Collider characterController, out HitEffectChooser effect) =>
            _objectEffects.TryGetValue(characterController, out effect);
    }
}