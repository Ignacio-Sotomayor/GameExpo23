using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Speed = 10f;
    public float JumpForce = 10f;

    private Transform player;
    private Rigidbody Body;

    private float HorizontalValue;
    private float VerticalValue;
    private bool IsGrounded =  true;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Body.AddForce(Vector3.up * JumpForce * JumpForce);
        }
    }



    void Mover()
    {
        HorizontalValue = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        VerticalValue = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        player.Translate(HorizontalValue, 0, VerticalValue);

    }

    void FixedUpdate(){
        int layerMask = 1<< 8;

        layerMask = ~layerMask;

        RaycastHit hit;

        if(Physics.Raycast(player.position, player.TransformDirection(Vector3.up * -1), out hit, 1.1f, layerMask)){
            IsGrounded = true;
        }else
        {
            IsGrounded = false;
        }
    }
}
