using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Ray ray;
    public float rayMaxDistance = 5;
    public float controlSliderValue = 0.5f;
    public float horizontalMovement;
    
    public override void  Start()
    {
        base.Start();
        ray = new Ray(CharacterData.transform.position, transform.up);

    }
    public override void Update()
    {
        controlSliderValue =CharacterData.MovementSlider.value;
        CheckForColliders();

        if (controlSliderValue > 0.6f)
            horizontalMovement = 1;
        else if (controlSliderValue < 0.4f)
            horizontalMovement = -1;
        else horizontalMovement = 0;
       

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
