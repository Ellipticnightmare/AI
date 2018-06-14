using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 100f;
        [Header("UI")]
        public GameObject healthbarUI;
        public Vector2 healthBarOffset = new Vector2(0f, 5f);

        private Slider healthSlider;
        private float health = 100f;

        void Start()
        {
            health = maxHealth;
        }

        void OnDestroy()
        {
            if (healthSlider)
            {
                Destroy(healthSlider.gameObject);
            }
        }

        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            Vector2 position = cam.WorldToScreenPoint(transform.position);
            return position + healthBarOffset;
        }

        void Update()
        {
            if (healthSlider)
            {
                healthSlider.transform.position = GetHealthBarPos();
            }
        }

        public void SpawnHealthBar(Transform parent)
        {
            GameObject clone = Instantiate(healthbarUI, 
                                            GetHealthBarPos(), 
                                            Quaternion.identity,
                                            parent);

            healthSlider = clone.GetComponent<Slider>();
        }

        public void DealDamage(float damage)
        {
            health -= damage;

            if (healthSlider)
            {
                healthSlider.value = health / maxHealth;
            }

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

