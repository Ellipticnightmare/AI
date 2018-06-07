using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense
{
    public class AIAgent : MonoBehaviour
    {
        public Transform target;

        private NavMeshAgent nav;

        private void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (target)
            {
                nav.SetDestination(target.position);
            }
        }
    }
}


