using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MainSource
{
    public class ShootController : MonoBehaviour
    {

        [SerializeField] private ExplosionController m_explisionController;
        [SerializeField] private Transform m_cameraTransform;
        [SerializeField] private float _rayDistance;
        [SerializeField] private LayerMask _rayMask;
        [SerializeField] private LayerMask _explsionMask;
        [SerializeField] private float m_explosionRadius;
        [SerializeField] private float m_explosionForce;
        [SerializeField] private float m_verticalOffset;

        private float m_radiusReciprocal;

        void Start()
        {
            InputControl.OnPrimaryInput += PrimaryFireHandler;
        }

        private void OnEnable()
        {
            m_radiusReciprocal = 1f / m_explosionRadius;
            m_explisionController.ApplyRadius(m_explosionRadius);
        }

        private void PrimaryFireHandler()
        {
            Ray ray = new Ray(m_cameraTransform.position, m_cameraTransform.forward);
            Vector3 _hitPoint = m_cameraTransform.position + m_cameraTransform.forward * _rayDistance;
            if (Physics.Raycast(ray, out RaycastHit hitInfo, _rayDistance, _rayMask))
            {
                _hitPoint = hitInfo.point;

                Collider[] colliders = Physics.OverlapSphere(_hitPoint, m_explosionRadius, _explsionMask);

                HashSet<Rigidbody> _targets = new HashSet<Rigidbody>();

                for (int i = 0; i < colliders.Length; ++i)
                {
                    Rigidbody rigidbody = colliders[i].attachedRigidbody;
                    _targets.Add(rigidbody);
                }

                foreach (Rigidbody rigidbody in _targets)
                {
                    if (rigidbody == null)
                        continue;
                    Vector3 direction = rigidbody.position - (_hitPoint + Vector3.up * m_verticalOffset);
                    rigidbody.AddForce(
                        direction.normalized * m_explosionForce * Mathf.Clamp01(1f - direction.magnitude * m_radiusReciprocal),
                        ForceMode.Impulse);
                }

                Instantiate(m_explisionController, _hitPoint, Quaternion.identity).Play();
            }
        }
    }
}
