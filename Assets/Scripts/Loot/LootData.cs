using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootData : MonoBehaviour
{
    [SerializeField] private float cost;
    [SerializeField] private Transform lootTransform;
    [SerializeField] private float weight;
    [SerializeField] private Rarity rarity;
    [SerializeField] private Rigidbody lootRigidbody;
    [SerializeField] private Collider lootCollider;
    [SerializeField] private int[,,,] space; 

    public float Cost => cost;
    public float Weight => weight;
    public Transform LootTransform => lootTransform;
    public Rigidbody LootRigidbody => lootRigidbody;
    public Collider LootCollider => lootCollider;

    public Rarity Rarity => rarity;
}
