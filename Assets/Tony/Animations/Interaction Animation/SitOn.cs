using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SitOn : MonoBehaviour //attach on objects like chairs etc
{
    private GameObject player;
    
    private Animator anim;
    bool sittingOn = false;
    public bool OnClick;
    public Transform sitPosition;
    public float distance;

    private void OnMouseDown()
    {
        SitOn[] array = FindObjectsOfType<SitOn>();
        foreach(SitOn s in array)
        {
            s.OnClick = false;
            s.transform.GetComponent<BoxCollider>().enabled = true;
        }
        OnClick = true;
        if (FindObjectOfType<HouseUICtrl>())
        {
            if (FindObjectOfType<HouseUICtrl>().isDecoreting)
            {
                OnClick = false;
            }
        }

    }



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.transform.GetChild(0).GetComponent<Animator>(); //use transform instead of gameObject to get more precise component
    }

   

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < distance)
        {
            if (OnClick)
            {
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(sitPosition.position.x, sitPosition.position.y, sitPosition.position.z);
                player.GetComponent<CharacterController>().enabled = true;

                player.GetComponent<Rigidbody>().useGravity = false;
                player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().isKinematic = true; //so gravity won't affect the chair
                GetComponent<BoxCollider>().enabled = false; //so it won't collide with player's collider

                player.transform.rotation = transform.rotation; //immediate snaps rotation
                sittingOn = true;
                //turn player around to align forward vector with object's vector aka they're facing same direction                
            }
        }
        else
        {
            sittingOn = false;
            //Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
            OnClick = false;
            GetComponent<Rigidbody>().isKinematic = false; //so gravity won't affect the chair
            GetComponent<BoxCollider>().enabled = true; //so it won't collide with player's collider
            player.GetComponent<Rigidbody>().useGravity = true;                                
        }

        if (player.GetComponent<PlayerMovement>().arrowsKeyPressed)
            OnClick = false;

        if (player.transform.position.x == sitPosition.position.x && player.transform.position.z == sitPosition.position.z && sittingOn)
        {
                player.GetComponent<PlayerMovement>().transitState(PlayerMovement.MotionState.Sitting);
        }
    }
}
