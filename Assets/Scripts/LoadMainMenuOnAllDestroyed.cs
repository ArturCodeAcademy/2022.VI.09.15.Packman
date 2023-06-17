using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenuOnAllDestroyed : MonoBehaviour
{
    private static HashSet<Transform> _objects = new HashSet<Transform>();

    private void Start()
    {
        _objects.Add(transform);
    }

    private void OnDestroy()
    {

        if (_objects.Remove(transform) && _objects.Count <= 0)
            SceneManager.LoadScene(0);
    }
}
