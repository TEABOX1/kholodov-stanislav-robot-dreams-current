using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_14
{
    public class StoneEffect : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private ParticleSystem m_stone;

        // Update is called once per frame
        public void Play()
        {
            m_stone.Play(true);
        }

        public ParticleSystem GetParticleSystem()
        {
            return m_stone;
        }
    }
}
