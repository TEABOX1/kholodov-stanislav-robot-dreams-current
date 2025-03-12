using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Lesson_14
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI m_scoreNumber;
        [SerializeField] protected TextMeshProUGUI m_headScoreNumber;

        private int m_savedScore = 0;
        private int m_savedHeadScore = 0;

        private void Awake()
        {
        }

        public void setScore()
        {
            m_savedScore += 1;
            m_scoreNumber.SetText(m_savedScore.ToString());
        }

        public void setHeadScore()
        {
            m_savedHeadScore += 5;
            m_headScoreNumber.SetText(m_savedHeadScore.ToString());
        }
    }
}
