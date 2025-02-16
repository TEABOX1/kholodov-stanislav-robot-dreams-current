using UnityEngine;

namespace Lesson4.AbstractFlavour
{
    public abstract class DistanceCheckerBase
    {
        public const float GIZMOS_SPHERE_RADIUS = .125f;
        public const float GIZMOS_RAY_DISTANCE = 100f;

        [SerializeField] protected Vector3 position;

        public Vector3 Position => position;
        
        protected DistanceCheckerBase(Vector3 position)
        {
            this.position = position;
        }

        public abstract bool IsInRange(Vector3 position);

        public virtual void DrawGizmos()
        {
            Gizmos.DrawSphere(position, GIZMOS_SPHERE_RADIUS);
        }

        protected void DrawRays(Vector3[] points)
        {
            for (int i = 0; i < points.Length; i++)
                Gizmos.DrawRay(points[i], Vector3.up * GIZMOS_RAY_DISTANCE);
        }
    }

}
