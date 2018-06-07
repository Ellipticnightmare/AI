using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        public float damage = 10f;
        public float attackDelay = 1f;

        protected Enemy currentEnemy;

        private float attackTimer = 0f;

        public virtual void PrintName()
        {
            print("Tower");
        }

        public virtual void Aim(Enemy e) { }
        public virtual void Attack(Enemy e) { }

        protected virtual void Update()
        {
            attackTimer += Time.deltaTime;
            if (currentEnemy)
            {
                Aim(currentEnemy);
                if(attackTimer >= attackDelay)
                {
                    Attack(currentEnemy);
                    attackTimer = 0f;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();
            if(hitEnemy && currentEnemy == null)
            {
                currentEnemy = hitEnemy;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();
            if(hitEnemy && currentEnemy == null)
            {
                currentEnemy = hitEnemy;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();
            if(hitEnemy && currentEnemy == hitEnemy)
            {
                currentEnemy = null;
            }
        }
    }
}

