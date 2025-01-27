using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float tilt;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Transform characterGeoTransform;
    [SerializeField] private Slider movementSlider;
    [SerializeField] private CharacterController characterController;

    public float DefaultSpeed => speed;
    public float DefaultTilt => tilt;
    public Transform CharacterTransform => characterTransform;
    public Transform CharacterGeoTransform => characterGeoTransform;
    public Slider MovementSlider => movementSlider;
    public CharacterController CharacterController => characterController;
}
