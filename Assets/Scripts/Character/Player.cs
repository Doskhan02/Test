using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Ray ray;
    public float rayMaxDistance = 7;
    public float controlSliderValue = 0.5f;
    public float horizontalMovement;
    
    public override void  Start()
    {
        base.Start();
        ray = new Ray(CharacterData.transform.position, transform.up);

    }
    public override void Update()
    {
        
        CheckForColliders();
        controlSliderValue = CharacterData.MovementSlider.value;
        if (controlSliderValue > 0.55f)
        {
            horizontalMovement = 0.5f;
            CharacterData.CharacterGeoTransform.rotation = Quaternion.Euler(new Vector3(75, -90, -90));
        }

        else if (controlSliderValue < 0.45f)
        {
            horizontalMovement = -0.5f;
            CharacterData.CharacterGeoTransform.rotation = Quaternion.Euler(new Vector3(105, -90, -90));
        }

        else
        {
            horizontalMovement = 0;
            CharacterData.CharacterGeoTransform.rotation = Quaternion.Euler(new Vector3(90, -90, -90));
        }
        
       

        if (CharacterData.transform.position.x > 4.4f)
            horizontalMovement = -1;
        if (CharacterData.transform.position.x < -4.4f)
            horizontalMovement = 1;

        float moveHorizontal = horizontalMovement;
        float moveVertical = 1;
        

        Vector3 movementVector = new Vector3(moveHorizontal, 0, moveVertical).normalized;
        
        movementComponent.Move(movementVector);
        movementComponent.Rotate(movementVector);
    }
    public void CheckForColliders()
    {
        if (Physics.Raycast(ray, out RaycastHit hitInfo,rayMaxDistance))
        {
            LootData lootData = hitInfo.collider.GetComponent<LootData>();
            if (lootData != null)
            {
                Lootbox.AddLoot(lootData);
                Lootbox.UpdateLoot(lootData);
            }
                

        }
    }
}
