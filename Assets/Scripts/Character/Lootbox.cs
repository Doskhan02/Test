using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Lootbox : MonoBehaviour
{
    private float offset = 0.8f;
    [SerializeField] Character ownerCharacter;
    private CharacterData characterData;
    LootData lootData;
    List<LootData> lootDataList = new List<LootData>();
    public void Initalize(CharacterData characterData)
    {
        this.characterData = characterData;
    }

    public void UpdateLoot(LootData data)
    {
        data.LootTransform.position =
            new Vector3(
                characterData.transform.position.x,
                characterData.transform.position.y + offset,
                characterData.transform.position.z);
    }

    public void AddLoot(LootData data)
    {
        data.LootCollider.enabled = false;
        Destroy(data.LootRigidbody);
        data.LootTransform.position = 
            new Vector3(
                characterData.transform.position.x,
                characterData.transform.position.y + offset, 
                characterData.transform.position.z);
        data.LootTransform.rotation = Quaternion.identity;
        lootDataList.Add(data);
    }
    public void Update()
    {
        if (lootDataList == null)
        {
            Debug.Log("no list");
            return;
        }
                    
        for (int i = 0; i < lootDataList.Count; i++)
        {
            lootData = lootDataList[i];
            UpdateLoot(lootData);
        }
        
    }
}
