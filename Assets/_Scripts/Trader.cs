using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    [SerializeField] List<GameObject> itemStock = new List<GameObject>();

    public List<GameObject> ItemStock { get => itemStock; set => itemStock = value; }
}
