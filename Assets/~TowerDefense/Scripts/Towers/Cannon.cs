using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Cannon : Tower
    {
        public Transform barrel;
        public float lineDelay = .2f;

        private LineRenderer line;

        // Use this for initialization
        void Awake()
        {
            line = GetComponent<LineRenderer>();   
        }

        public override void Aim(Enemy e)
        {
            barrel.LookAt(e.transform);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, barrel.position);
            line.SetPosition(2, e.transform.position);
        }

        public override void Attack(Enemy e)
        {

        }
    }
}

