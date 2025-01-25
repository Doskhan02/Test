using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    [SerializeField] LootData lootData;

    public LootData LootData => lootData;
    public virtual void Start()
    {
        lootData = GetComponent<LootData>();
    }

    public abstract void Update();
}
