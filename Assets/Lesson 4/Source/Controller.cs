using UnityEngine;
using Lesson4.AbstractFlavour;

public class Controller : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeReference] private DistanceCheckerBase m_distanceCheckerBase;

    [ContextMenu("Set Circle Checker")]
    private void setCircleChecker()
    {
        Vector3 position = m_distanceCheckerBase?.Position ?? Vector3.zero;
        m_distanceCheckerBase = new CircleChecker(position, 3f);
    }

    [ContextMenu("Check")]
    private void Check()
    {
        Debug.Log( $"In Range (Absctract Flavour): {m_distanceCheckerBase.IsInRange(m_target.position)}" );
    }

    private void OnDrawGizmosSelected()
    {
        m_distanceCheckerBase.DrawGizmos();
    }
}