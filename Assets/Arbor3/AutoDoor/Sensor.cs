using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
// A HashSet type field that stores the GameObject contained in the trigger.
    HashSet<GameObject> _EnteredObjects = new HashSet<GameObject>();

    // Returns the number of GameObjects currently in the trigger.
    public int enteredCount
    {
        get
        {
            return _EnteredObjects.Count;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the GameObject that came in the trigger is a Player tag, store it in _EnteredObjects.
        var gameObject = other.gameObject;
        if (gameObject.CompareTag("Player"))
        {
            if (_EnteredObjects.Add(gameObject))
            {
                // If stored, the current count is displayed in the Console.
                Debug.Log($"OnTriggerEnter : {_EnteredObjects.Count}");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // GameObjects that come out of the trigger are removed from _EnteredObjects.
        var gameObject = other.gameObject;
        if (_EnteredObjects.Remove(gameObject))
        {
            // If removed, the current count is displayed in the Console.
            Debug.Log($"OnTriggerExit : {_EnteredObjects.Count}");
        }
    }
}
