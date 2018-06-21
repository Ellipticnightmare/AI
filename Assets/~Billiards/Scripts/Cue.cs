using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class Cue : MonoBehaviour
    {
        public Ball targetBall;
        public float minPower = 0f;
        public float maxPower = 20f;
        public float maxDistance = 5f;

        private float hitPower;
        private Vector3 aimDirection;
        private Vector3 prevMousePos;
        private Ray mouseRay;

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(targetBall.transform.position, targetBall.transform.position + aimDirection * hitPower);
        }

        void Aim()
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(mouseRay, out hit))
            {
                Vector3 dir = transform.position - hit.point;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                transform.position = targetBall.transform.position;
            }
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            Aim();
            gameObject.SetActive(true);
        }

        void Drag()
        {
            Vector3 targetPos = targetBall.transform.position;
            Vector3 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector3.Distance(prevMousePos, currMousePos);
            distance = Mathf.Clamp(distance, 0, maxDistance);
            float distPercentage = distance / maxDistance;
            hitPower = Mathf.Lerp(minPower, maxPower, distPercentage);
            transform.position = targetPos - transform.forward * distance;
            aimDirection = (targetPos - transform.position).normalized;
        }

        void Fire()
        {
            targetBall.Hit(aimDirection, hitPower);
            Deactivate();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                prevMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                Drag();
            }
            else
            {
                Aim();
            }

            if (Input.GetMouseButtonUp(0))
            {
                Fire();
            }
        }
    }
}


