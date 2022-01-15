using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitOn : MonoBehaviour //attach on objects like chairs etc
{
    public GameObject player;
    private Animator anim;
    bool isWalkingTowards = false;
    bool sittingOn = false;

    private void OnMouseDown()
    {
        if (!sittingOn)
        {
            anim.SetTrigger("isWalking");
            isWalkingTowards = true;
        }
        
    }



    void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkingTowards)
        {
            Vector3 targetDir;
            targetDir = new Vector3(transform.position.x - player.transform.position.x, 0f, transform.position.z - player.transform.position.z);

            Quaternion rot = Quaternion.LookRotation(targetDir);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rot, 0.05f);
            player.transform.Translate(Vector3.forward * 0.01f);

            if(Vector3.Distance(player.transform.position, this.transform.position) < 0.7)
            {
                anim.SetTrigger("isSitting");

                //turn player around to align forward vector with object's vector aka they're facing same direction

                player.transform.rotation = this.transform.rotation; //immediate snaps rotation
                isWalkingTowards = false;
                sittingOn = true;
            }
        }
    }
}
