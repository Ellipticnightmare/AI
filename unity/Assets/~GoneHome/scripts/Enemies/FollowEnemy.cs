using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GoneHome
{
    public class FollowEnemy : MonoBehaviour
    {
        public Transform target;

        private NavMeshAgent agent;

        private Vector3 spawnPoint;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }

        public void Reset()
        {
            transform.position = spawnPoint;
        }
    }
}

