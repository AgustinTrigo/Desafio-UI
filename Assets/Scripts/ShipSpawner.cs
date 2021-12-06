using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipSpawner : MonoBehaviour
{

    [SerializeField] private UnityEvent onSpawnShip;

   private void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.CompareTag("Player"))
        {
            onSpawnShip?.Invoke();
        }
   }

}
