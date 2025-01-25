using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    [SerializeField] Lootbox lootbox;

    public CharacterData CharacterData => characterData;
    public Lootbox Lootbox => lootbox;
    
    public IMovementComponent movementComponent;

    public virtual void Start()
    {
        characterData = GetComponent<CharacterData>();
        movementComponent = new MovementComponent();

        movementComponent.Initialize(characterData);
        lootbox.Initalize(characterData);
        
    }
    public abstract void Update();
}

