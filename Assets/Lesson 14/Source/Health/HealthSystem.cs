#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_14
{
    public class HealthSystem : MonoBehaviour
    {
        public event Action<Health> OnCharacterDeath;

        [SerializeField] private Health[] _healths;

        protected Dictionary<DummyClass, Health> _charactersHealth = new();

        public IEnumerable<Health> CharactersHealth => _charactersHealth.Values;

        /// <summary>
        /// Editor only method
        /// </summary>
        [ContextMenu("Find Healths")]
        private void FindHealths()
        {
#if UNITY_EDITOR
            _healths = FindObjectsOfType<Health>();
            EditorUtility.SetDirty(this);
#endif
        }

        protected virtual void Awake()
        {
            for (int i = 0; i < _healths.Length; ++i)
            {
                Health health = _healths[i];
                _charactersHealth.Add(health.GeneralCollider, health);
                health.OnDeath += () => CharacterDeathHandler(health);
            }
        }

        public virtual bool GetHealth(Collider Collider, out Health health)
        {
            foreach (var pair in _charactersHealth)
            {
                DummyClass dummy = pair.Key;

                if (dummy == null) continue;

                if (dummy.CharacterController == Collider || dummy.HeadCollider == Collider)
                {
                    health = pair.Value;
                    return true;
                }
            }
            health = null;
            return false;
            //return _charactersHealth.TryGetValue(Collider, out health);
        }
        protected void CharacterDeathHandler(Health health)
        {
            OnCharacterDeath?.Invoke(health);
        }
    }
}