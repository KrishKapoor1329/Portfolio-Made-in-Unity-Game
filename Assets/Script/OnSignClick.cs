using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSignClick : MonoBehaviour
{

    [SerializeField] public string signText;
    bool helpButtonClicked = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.name.Equals("helpSign") && helpButtonClicked == true)
        {
            Debug.Log("Check 1 2");
            helpButtonClicked = false;
            pressButtonClicked();
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {


            
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)

            {
                //Debug.Log(hit.collider.gameObject.name);
                // clicked = true;
                //string playName = hit.collider.gameObject.name;

                if (hit.collider.gameObject.name == this.gameObject.name)
                {
                    PopUpSystem.PopUp(signText);
                    //  songName = "Song " + playName.Substring(playName.Length - 1);
                    //  hit.collider.attachedRigidbody.AddForce(Vector2.up);
                    Debug.Log(this.gameObject.name);
                }
            }
        }
    }

    public void pressButtonClicked()
    {
        //helpButtonClicked = true;
        //if (helpButtonClicked == true)
        //{
            PopUpSystem.PopUp(signText);
            helpButtonClicked = false;
            return;
       // }
    }


    
}
