using System;
using System.Collections.Generic;
using UnityEngine;

//Inventory is linked to PlayerObject (for Start() Method)
public class Inventory : MonoBehaviour
{
    
    public static Inventory Instance;
    [Range(10,20)]
    public int InventorySize;
    //public for testing purposes
    public List<GameObject> _objects;
    public delegate void OnSuccessfulAdd(); 

    //https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    private void Awake()
    {
        //deletes the (second) instance if somehow a second one gets instantiated
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private Inventory() { }

    public static Inventory GetInstance() { return Instance; }

    private void Start()
    {
        _objects = new List<GameObject>();
    }

    public void AddObject(GameObject _object, OnSuccessfulAdd on)
    {
        byte oldCount = (byte) _objects.Count;
        if (this.HasSpace())
        {
            _objects.Add(_object);
            if (oldCount < _objects.Count) on();
        }
        else Debug.Log("No more space in the inventory...");
    }

    public bool HasSpace()
    {
        return _objects.Count < this.InventorySize;
    }

    public bool Has(string name)
    {
        for (int elem = 0; elem < _objects.Count; elem++) if (_objects[elem].name.Contains(name)) return true;
        return false;
    }

    public void RemoveFirst(string name)
    {
        for (int elem = 0; elem < _objects.Count; elem++)
        {
            if (_objects[elem].name.Contains(name))
            {
                //the object still exists for a bit after destruction event init
                Destroy(_objects[elem]);
                _objects.Remove(_objects[elem]);
                break;
            }
        }
    }
}
