using UnityEngine;

namespace Lesson13
{
    public class LasserAspect : MonoBehaviour
    {
        public MaterialPropertyBlock outerPropertyBlock;

        [HideInInspector] public float distance;

        [SerializeField] private Transform m_transform;
        [SerializeField] private MeshRenderer m_outer;
        [SerializeField] private MeshRenderer m_inner;

        public Transform Transform => m_transform;
        public MeshRenderer Outer => m_outer;
        public MeshRenderer Inner => m_inner;
    }
}