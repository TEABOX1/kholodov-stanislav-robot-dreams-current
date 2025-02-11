using System.Collections.Generic;
using UnityEngine;
using Lesson_2.Source;
using System;

public class Lesson2 : MonoBehaviour
{
    [SerializeField] private int m_value;
    private ListWrapper<int> m_valueList;
    enum SortType
    {
        Ascending,
        Descending,
        DescendingDirect,
        DescendingBToA,
        DescendingDirectFull
    }
    [SerializeField] SortType m_sortType = SortType.Ascending;

    [ContextMenu("Force OG")]
    public void ForceGC()
    {
        GC.Collect();
    }

    [ContextMenu( "Create List" )]
    private void createList()
    {
        if(m_valueList != null)
        {
            Debug.Log("List already created");
            return;
        }
        m_valueList = new ListWrapper<int>();
        Debug.Log("List created and ready for work");
    }

    [ContextMenu("ReCreate List")]
    private void reCreateList()
    {
        if(m_valueList != null)
        {
            Debug.Log("Previous list was moved to Garbage");
        }
        m_valueList = new ListWrapper<int>();
        Debug.Log("List was recreated");
    }

    [ContextMenu( "Remove List" )]
    private void removeList()
    {
        m_valueList = null;
        Debug.Log( "List was removed to Grabage" );
    }

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
            case SortType.DescendingDirect:
                m_valueList.Sort( descendingComparisonDirect );
                break;
            case SortType.DescendingBToA:
                m_valueList.Sort( descendingComparisonBtoA );
                break;
            case SortType.DescendingDirectFull:
                m_valueList.Sort( descendingComparisonDirectFull );
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

    private int descendingComparisonDirect( int a, int b )
    {
        return a == b ? 0 : a > b ? -1 : 1;
    }

    private int descendingComparisonBtoA( int a, int b )
    {
        return b.CompareTo(a);
    }

    private int descendingComparisonDirectFull(int a, int b)
    {
        if( a == b )
            return 0;
        if (a > b)
            return -1;
        return 1;
    }
}
