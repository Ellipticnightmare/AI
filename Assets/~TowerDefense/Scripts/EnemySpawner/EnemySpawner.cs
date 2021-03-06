﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemySpawner : Spawner
    {
        public Transform path;
        [Header("UI")]
        public Transform healthBarParent;

        private Transform start;
        private Transform end;

        void GetPath()
        {
            if(path != null)
            {
                start = path.FindChild("Start");
                end = path.FindChild("End");
            }
        }

        // Use this for initialization
        void Start()
        {
            GetPath();
        }

        public override void Spawn()
        {
            GameObject clone = Instantiate(prefab, start.position, start.rotation);
            clone.transform.SetParent(transform);
            AIAgent agent = clone.GetComponent<AIAgent>();
            agent.target = end;
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.SpawnHealthBar(healthBarParent);
        }
    }
}

