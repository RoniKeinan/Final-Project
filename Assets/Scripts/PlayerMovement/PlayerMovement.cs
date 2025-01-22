using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    InputManager inputManager;
    Vector3 moveDirection;
    Transform cameragameObject;
    Rigidbody playerRigidbody;
    public float movementSpeed=2f;
    public float rotationSpeed=13f; 



    void Awake()
    {
        inputManager=GetComponent<InputManager>();
        playerRigidbody=GetComponent<Rigidbody>();
        cameragameObject=Camera.main.transform;
    }

     public void HandleAllMovement()
     {
       HandleMovement();
       HandleRotation();
     }
    public void HandleMovement()
    {
       moveDirection=cameragameObject.forward*inputManager.verticalInput;
       moveDirection=moveDirection+cameragameObject.right* inputManager.horizontalInput;
       moveDirection.Normalize();

       moveDirection.y=0;

       moveDirection=moveDirection*movementSpeed;

       Vector3 movementVelocity =moveDirection;
       playerRigidbody.linearVelocity=movementVelocity;
    }
    public void HandleRotation()
    {
        Vector3 targetDirection=Vector3.zero;
        targetDirection=cameragameObject.forward*inputManager.verticalInput;
        targetDirection=targetDirection+cameragameObject.right* inputManager.horizontalInput;
        targetDirection.Normalize();

       targetDirection.y=0;

       if(targetDirection==Vector3.zero)
       {
        targetDirection=transform.forward;

       }

       Quaternion targetRotation= Quaternion.LookRotation(targetDirection);
       Quaternion playerRotation= Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);


       transform.rotation=playerRotation; 
    }
}
