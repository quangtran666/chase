using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [Header("References")] 
    [SerializeField] private InputControls inputControls;
}
