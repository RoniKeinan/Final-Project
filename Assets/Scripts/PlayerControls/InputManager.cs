using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager:MonoBehaviour
{
  @PlayerControls playerControls;
  AnimatorManager animatorManager;
  public Vector2 movementInput;

  public float verticalInput;
  public float horizontalInput;

  private float movementAmount;

  void Awake()
  {
    animatorManager=GetComponent<AnimatorManager>();
  }


  void OnEnable(){
    if(playerControls==null){
      playerControls=new @PlayerControls();
      playerControls.PlayerMovement.Movement.performed+=i =>movementInput=i.ReadValue<Vector2>();
    }
    playerControls.Enable();
  }


  public void OnDisable(){
    playerControls.Disable();
  }

  public void HandleAllInputs()
  {
    HandleMovementInput();
  }

  public void HandleMovementInput()
  {
     verticalInput=movementInput.y;
     horizontalInput=movementInput.x;
     movementAmount=Mathf.Clamp01(Mathf.Abs(verticalInput)+Mathf.Abs(horizontalInput));
     animatorManager.ChangeAnimatorValues(0,movementAmount);
  }
  
}
