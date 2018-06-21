using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class DestroyOnTrigger : MonoBehaviour
    {
        public string nameContains;

        void OnTriggerEnter(Collider col)
        {
            if (col.name.Contains(nameContains))
            {
                Destroy(col.gameObject);
            }
        }
    }
}

