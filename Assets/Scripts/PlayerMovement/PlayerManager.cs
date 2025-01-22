using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerMovement1 playerMovement;
    
    void Awake()
    {
        inputManager=GetComponent<InputManager>();
        playerMovement=GetComponent<PlayerMovement1>();
    }

    void Update()
    {
        inputManager.HandleAllInputs();
    }

    void FixedUpdate()
    {
        playerMovement.HandleAllMovement();
    }
}
