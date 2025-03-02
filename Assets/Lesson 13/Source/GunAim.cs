using Assets.MainSource;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson13
{
    public class GunAim : MonoBehaviour
    {
        [SerializeField] private Transform _gunTransform;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private float m_rayDistance;
        [SerializeField] private LayerMask m_rayMask;
        [SerializeField] private CinemachineMixingCamera m_mixingCamera;
        [SerializeField] private float m_aimSpeed;


        private Vector3 m_hitPoint;
        private float m_aimValue;
        private float m_targetAimValue;

        public Vector3 AimPoint => m_hitPoint;

        private void OnEnable()
        {
            InputControl.OnSecondaryInput += SecondaryInputHandler;
        }

        private void OnDisable()
        {
            InputControl.OnSecondaryInput -= SecondaryInputHandler;
        }

        private void FixedUpdate()
        {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
            m_hitPoint = _cameraTransform.position + _cameraTransform.forward * m_rayDistance;
            if (Physics.Raycast(ray, out RaycastHit hitInfo, m_rayDistance, m_rayMask))
                m_hitPoint = hitInfo.point;
            _gunTransform.LookAt(m_hitPoint);
        }

        private void Update()
        {
            m_aimValue = Mathf.MoveTowards(m_aimValue, m_targetAimValue, m_aimSpeed * Time.deltaTime);
            m_mixingCamera.m_Weight0 = 1f - m_aimValue;
            m_mixingCamera.m_Weight1 = m_aimValue;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_gunTransform.position, m_hitPoint);
        }

        private void SecondaryInputHandler(bool performed)
        {
            m_targetAimValue = performed ? 1f : 0f;
        }
    }
}
