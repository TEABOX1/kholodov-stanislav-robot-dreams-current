using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson_14
{
    public class DummyClass : MonoBehaviour
    {
        [SerializeField] protected CharacterController _characterController;
        [SerializeField] protected SphereCollider _headCollider;

        public CharacterController CharacterController => _characterController;
        public SphereCollider HeadCollider => _headCollider;
        public void SetCharecterCollider(CharacterController characterController)
        {
            _characterController = characterController;
        }
        public void SetHeadCollider(SphereCollider headCollider)
        {
            _headCollider = headCollider;
        }
    }
}
