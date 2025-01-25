using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner_Movement_Component : IMovementComponent
{
    private CharacterData characterData;
    public float speed = 0f;
    private float speedMultiplier = 0.5f;
    public float Speed
    {
        get => speed;
        set
        {
            if (speed < 0f)
                return;
            speed = value;
        }
    }

    public void Initialize(CharacterData characterData)
    {
        this.characterData = characterData;
        speed = characterData.DefaultSpeed;
    }

    public void Move(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Vector3 move = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        characterData.CharacterController.Move(move * Speed * Time.deltaTime);
    }

    public void Rotate(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }
}
