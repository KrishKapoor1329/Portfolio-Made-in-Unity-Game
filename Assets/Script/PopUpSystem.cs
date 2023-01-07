using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PopUpSystem : MonoBehaviour
{
    public static GameObject popUpBox;
    public static Animator animator;
    // public TMP_Text popUpText;
    public static Canvas EscCan;

    public static void PopUp(string s)
    {
        popUpBox = GameObject.Find("PopUpBox");
        animator = popUpBox.GetComponent<Animator>();
        //popUpBox.GetComponentInChildren
        popUpBox.SetActive(true);
        GameObject tempObject = GameObject.Find("Canvas");

        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            EscCan = tempObject.GetComponent<Canvas>();
            if (EscCan == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }

            EscCan.GetComponentInChildren<Text>().text = s;
        }
            // popUpText.text = text;
            animator.SetTrigger("pop");

        animator.ResetTrigger("close");
    }


    public void CloseBox()
    {
        popUpBox = GameObject.Find("PopUpBox");
        animator = popUpBox.GetComponent<Animator>();
        animator.SetTrigger("close");
        animator.ResetTrigger("pop");
    }
}
