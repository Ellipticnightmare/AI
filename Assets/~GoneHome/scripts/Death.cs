using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoneHome
{
    public class Death : MonoBehaviour
    {
        public UnityEvent onDeath;
        
        //Gets called when Triggered by other object
        private void OnTriggerEnter(Collider other)
        {
            if(other.name == "DeathZone" ||
                other.name == "FolowEnemy")
            {
                //KILL IT WITH FIERY VENGEANCE!
                onDeath.Invoke();
            }
        }
    }
}

