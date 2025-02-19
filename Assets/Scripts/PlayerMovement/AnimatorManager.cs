using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
   Animator animator;
   int horizontalValue;
   int verticalValue;

   void Awake()
    {
      animator=GetComponent<Animator>();
      horizontalValue=Animator.StringToHash("Horizontal");
      verticalValue=Animator.StringToHash("Vertical");
    }
   
   public void ChangeAnimatorValues(float horizontalMovement,float verticalMovement)
   {
    animator.SetFloat(horizontalValue,horizontalMovement,0.1f,Time.deltaTime);
    animator.SetFloat(verticalValue,verticalMovement,0.1f,Time.deltaTime);
   }
}
