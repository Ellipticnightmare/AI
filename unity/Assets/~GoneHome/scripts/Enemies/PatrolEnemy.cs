using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class PatrolEnemy : MonoBehaviour
    {
        public Transform waypointGroup;
        public float movementSpeeed = 10f;
        // How close the enemy needs to be to switch waypoints
        public float closeness = 1f;

        private Transform[] waypoints;
        private int currentIndex = 0;

        private Vector3 spawnPoint;

        // Use this for initialization
        void Start()
        {
            int length = waypointGroup.childCount;
            waypoints = new Transform[length];
            for (int i = 0; i < length; i++)
            {
                waypoints[i] = waypointGroup.GetChild(i);
            }
        }

        // Update is called once per frames
        void Update()
        {
            Transform current = waypoints[currentIndex];

            Vector3 position = transform.position;
            Vector3 direction = current.position - position;
            position += direction.normalized * movementSpeeed * Time.deltaTime;

            transform.position = position;

            float distance = Vector3.Distance(position, current.position);

            if (distance <= closeness)
            {
                currentIndex++;
            }

            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 0;
            }
        }

        public void Reset()
        {
            transform.position = spawnPoint;
            currentIndex = 0;
        }
    }
}


