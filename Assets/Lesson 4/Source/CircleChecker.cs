using System;
using UnityEngine;

namespace Lesson4.AbstractFlavour
{
    [Serializable]
    public class CircleChecker:DistanceCheckerBase
    {
        [SerializeField] private float m_radius;

        public CircleChecker(Vector3 position, float radius) : base(position)
        {
            m_radius = radius;
        }

        public override bool IsInRange(Vector3 position)
        {
            float xFactor = position.x - this.position.x;
            float zFactor = position.z - this.position.z;
            return xFactor * xFactor + zFactor * zFactor <= m_radius * m_radius;
        }

        public override void DrawGizmos()
        {
            Gizmos.color = Color.green;
            base.DrawGizmos();
            DrawCircle();
        }

        private void DrawCircle()
        {
            float angleStep = 2f * Mathf.PI / 24f;
            Vector3[] circlePositions = new Vector3[24];
            circlePositions[0] = position + new Vector3(m_radius, 0f, 0f);
            for (int i = 1; i < 24; i++)
            {
                float angle = angleStep * i;
                circlePositions[i] = position + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * m_radius;
            }
            Gizmos.DrawLineStrip(circlePositions, true);
            DrawRays(circlePositions);
        }
    }
}