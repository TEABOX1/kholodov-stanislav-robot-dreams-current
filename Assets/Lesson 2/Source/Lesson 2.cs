using System.Collections.Generic;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    [SerializeField] private int m_value;
    private List<int> m_valueList = new List<int>();
    enum SortType
    {
        Ascending,
        Descending
    }
    [SerializeField] SortType m_sortType = SortType.Ascending;

    [ContextMenu( "Add Value" )]
    private void addValue()
    {
        if (m_valueList == null)
        {
            Debug.Log("List not created");
            return;
        }
        m_valueList.Add( m_value );
        //Print Updated list;
        printList();
    }

    [ContextMenu( "Remove Value" )]
    private void removeValue()
    {
        if (m_valueList == null)
        {
            Debug.Log("List not created");
            return;
        }
        m_valueList.Remove( m_value );
        //Print Updated list;
        printList();
    }

    [ContextMenu( "Remove First Value" )]
    private void removeFirstValue()
    {
        if (m_valueList == null)
        {
            Debug.Log("List not created");
            return;
        }
        m_valueList.RemoveAt( 0 );
        //Print Updated list;
        printList();
    }

    [ContextMenu( "Remove Last Value" )]
    private void removeLastValue()
    {
        if (m_valueList == null)
        {
            Debug.Log("List not created");
            return;
        }
        m_valueList.RemoveAt( m_valueList.Count - 1 );
        //Print Updated list;
        printList();
    }

    [ContextMenu("Print List")]
    private void printList()
    {
        if (m_valueList == null)
        {
            Debug.Log("List not created");
            return;
        }
        string shownList = string.Empty;
        if( m_valueList.Count <= 0 )
        {
            Debug.Log( "List is empty" );
            return;
        }
        for( int i = 0; i < m_valueList.Count; i++ )
        {
            shownList += m_valueList[i] + "\n";
        }
        Debug.Log( shownList );
    }

    [ContextMenu( "Clear List" )]
    private void clearList()
    {
        if (m_valueList == null)
        {
            Debug.Log("List not created");
            return;
        }
        m_valueList.Clear();
        //Print Updated list;
        printList();
    }

    [ContextMenu( "Sort List" )]
    private void sortList()
    {
        if (m_valueList == null)
        {
            Debug.Log("List not created");
            return;
        }
        switch ( m_sortType )
        {
            case SortType.Ascending:
                m_valueList.Sort();
                break;
            case SortType.Descending:
                m_valueList.Sort( descendingComparison );
                break;
            default:
                m_valueList.Sort();
                break;
        }
        //Print Updated list;
        printList();
    }

    private int descendingComparison( int a, int b )
    {
        return -a.CompareTo(b);
    }
}
