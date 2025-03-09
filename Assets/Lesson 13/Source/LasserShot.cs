using Assets.MainSource;
using Lesson13;
using System;
using System.Collections;
using UnityEngine;

namespace Lesson13
{
    public class LasserShot : MonoBehaviour
    {
        public event Action<Collider> OnHit;
        public event Action OnShot;

        [SerializeField] protected GunAim m_aimer;
        [SerializeField] protected LasserAspect m_shotPrefab;
        [SerializeField] protected Transform m_muzzleTransform;
        [SerializeField] protected float m_decaySpeed;
        [SerializeField] protected Vector3 m_shotScale;
        [SerializeField] protected float m_shotRadius;
        [SerializeField] protected float m_shotVisualDiameter;
        [SerializeField] protected string m_tilingName;
        [SerializeField] protected float m_range;
        [SerializeField] protected LayerMask m_layerMask;

        protected int _tilingId;

        protected virtual void Start()
        {
            _tilingId = Shader.PropertyToID(m_tilingName);
        }

        protected void OnEnable()
        {
            InputControl.OnPrimaryInput += PrimaryInputHandler;
        }

        protected void OnDisable()
        {
            InputControl.OnPrimaryInput -= PrimaryInputHandler;
        }

        protected virtual void PrimaryInputHandler()
        {
            Vector3 muzzlePosition = m_muzzleTransform.position;
            Vector3 muzzleForward = m_muzzleTransform.forward;
            Ray ray = new Ray(muzzlePosition, muzzleForward);
            Vector3 hitPoint = muzzlePosition + muzzleForward * m_range;
            if (Physics.SphereCast(ray, m_shotRadius, out RaycastHit hitInfo, m_range, m_layerMask))
            {
                Vector3 directVector = hitInfo.point - m_muzzleTransform.position;
                Vector3 rayVector = Vector3.Project(directVector, ray.direction);
                hitPoint = muzzlePosition + rayVector;

                OnHit?.Invoke(hitInfo.collider);
            }

            LasserAspect shot = Instantiate(m_shotPrefab, hitPoint, m_muzzleTransform.rotation);
            shot.distance = (hitPoint - m_muzzleTransform.position).magnitude;
            shot.outerPropertyBlock = new MaterialPropertyBlock();
            StartCoroutine(ShotRoutine(shot));

            OnShot?.Invoke();
        }

        protected IEnumerator ShotRoutine(LasserAspect shot)
        {
            float interval = m_decaySpeed * Time.deltaTime;
            while (shot.distance >= interval)
            {
                EvaluateShot(shot);
                yield return null;
                shot.distance -= interval;
                interval = m_decaySpeed * Time.deltaTime;
            }

            Destroy(shot.gameObject);
        }

        protected void EvaluateShot(LasserAspect shot)
        {
            shot.Transform.localScale = new Vector3(m_shotScale.x, m_shotScale.y, shot.distance * 0.5f);
            Vector4 tiling = Vector4.one;
            tiling.y = shot.distance * 0.5f / m_shotVisualDiameter;
            shot.outerPropertyBlock.SetVector(_tilingId, tiling);
            shot.Outer.SetPropertyBlock(shot.outerPropertyBlock);
        }
    }
}