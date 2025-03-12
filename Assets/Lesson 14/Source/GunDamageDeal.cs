using System;
using Lesson13;
using UnityEngine;

namespace Lesson_14
{
    public class GunDamageDealer : MonoBehaviour
    {
        public event Action<int> OnHit;

        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private LasserShot _gun;
        [SerializeField] private int _damage;

        [SerializeField] protected ScoreSystem m_score;

        public LasserShot Gun => _gun;

        private int _headDamage = 0;

        private void Start()
        {
            _gun.OnHit += GunHitHandler;
            _headDamage = _damage * 2;
        }

        private void GunHitHandler(Collider Collider)
        {
            if (!_healthSystem.GetHealth(Collider, out Health health))
                return;

            if (Collider is CharacterController)
            {
                m_score.setScore();
                health.TakeDamage(_damage);
            }
            else if (Collider is SphereCollider)
            {
                m_score.setHeadScore();
                health.TakeDamage(_headDamage);
            }


            OnHit?.Invoke(health ? 1 : 0);
        }
    }
}