using UnityEngine;

[CreateAssetMenu(menuName = "Player/MovementData")]
public class PlayerMovementDataSO : ScriptableObject
{
    [Range(1, 15)] public float maxSpeed;
    [Range(0.1f, 100)] public float acceleration;
    [Range(0.1f, 100)] public float deacceleration;
}
