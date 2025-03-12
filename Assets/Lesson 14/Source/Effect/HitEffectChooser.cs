using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Lesson_14
{
    public class HitEffectChooser : MonoBehaviour
    {
        [SerializeField] protected Collider _characterController;

        public enum HitEffect
        {
            HE_Blood = 0,
            HE_Stone = 1
        }
        [SerializeField] private HitEffect m_hitEffect = HitEffect.HE_Blood;
        public Collider CharacterController => _characterController;

        public HitEffect GetEffectNumber()
        {
            return m_hitEffect;
        }
    };
}
