using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    float turnSpeed = 100f;

    Animator anim;

    int isWalkingHash;
    int walkDirHash;

    float vertical, horizontal, dir;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        walkDirHash = Animator.StringToHash("walkDir");
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if(horizontal != 0)
        {
            transform.Rotate(0f, horizontal * Time.deltaTime * turnSpeed, 0f, Space.Self);
        }

        if(vertical != 0)
        {
            anim.SetBool(isWalkingHash, true);
            dir = Mathf.Sign(vertical);
            anim.SetFloat(walkDirHash, dir);
        }
        else
        {
            anim.SetBool(isWalkingHash, false);
        }
    }
}
