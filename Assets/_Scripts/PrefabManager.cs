using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    static PrefabManager instance;
    public static PrefabManager Instance { get { return instance; } }

    [SerializeField] List<GameObject> PrefabItems;
    public List<GameObject> GetPrefabItems { get => PrefabItems; }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this.gameObject); 
        else instance = this;
    }
}
