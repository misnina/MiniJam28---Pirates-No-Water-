using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
   public Dialog dialog;
   private bool inArea = false;

   private void Update()
   {
       if (Input.GetButtonUp("Fire1") && PlayerController.instance.canMove && inArea)
       {
           TriggerDialog();
       }
   }

   public void TriggerDialog ()
   {
       FindObjectOfType<DialogManager>().StartDialog(dialog);
       inArea = false;
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Player")
       {
           inArea = true;
           this.transform.Find("Talky").gameObject.SetActive(true);
       }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
       if (other.tag == "Player")
       {
           inArea = false;
           this.transform.Find("Talky").gameObject.SetActive(false);
       }
   }
}
