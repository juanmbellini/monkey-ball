using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PillsManager : MonoBehaviour {
    /// <summary>
    /// Holds a reference to each pill game object in the field.
    /// </summary>
    private readonly List<GameObject> _pills = new List<GameObject>();

    private void Start() {
        FindPills();
    }

    /// <summary>
    /// Counts the amount of pills in the scene.
    /// </summary>
    private void FindPills() {
        var pillArray = GameObject.FindGameObjectsWithTag("PillPrefab");
        foreach (var pill in pillArray) {
            _pills.Add(pill);
        }
    }

    /// <summary>
    /// Indicates whether there are pills remaining in the field.
    /// </summary>
    /// <returns>True if there are pills remaining, or false otherwise.</returns>
    public bool PillsRemaining() {
        return _pills.Any(go => go.activeSelf);
    }
}