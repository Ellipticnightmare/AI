using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Selector : MonoBehaviour
    {
        public GameObject[] prefabs;
        public LayerMask layerMask;

        private GameObject[] instances;
        private Transform tower, hologram;
        private int currentTower;

        public void SelectTower(int index)
        {
            if (index < 0 || index > prefabs.Length)
                return;

            currentTower = index;
        }

        void GenerateInstances()
        {
            GameObject instance = instances[currentTower];
            if(instance == null)
            {
                instance = Instantiate(prefabs[currentTower]);
                instance.transform.SetParent(transform);

                tower = instance.transform.Find("Tower");
                hologram = instance.transform.Find("Hologram");

                tower.gameObject.SetActive(false);
                hologram.gameObject.SetActive(false);

                instances[currentTower] = instance;
            }
        }

        // Use this for initialization
        void Start()
        {
            instances = new GameObject[prefabs.Length];
            SelectTower(0);
        }

        // Update is called once per frame
        void Update()
        {
            GenerateInstances();

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(mouseRay, out hit, 1000f,layerMask, QueryTriggerInteraction.Ignore))
            {
                Placeable p = hit.transform.GetComponent<Placeable>();

                if(p && p.isPlaced == false)
                {
                    GameObject gHologram = hologram.gameObject;
                    GameObject gTower = tower.gameObject;

                    if(gHologram.activeSelf == false)
                    {
                        gHologram.SetActive(true);
                    }

                    GameObject instance = instances[currentTower];

                    instance.transform.position = p.transform.position;

                    if (Input.GetMouseButtonDown(0))
                    {
                        p.isPlaced = true;

                        gHologram.SetActive(false);
                        gTower.SetActive(true);

                        instance.transform.SetParent(p.transform);
                        instances[currentTower] = null;
                    }
                }
            }
        }
    }
}

