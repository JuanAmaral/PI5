/*/
* Script by Devin Curry
* http://Devination.com
* https://youtube.com/user/curryboy001
* Please like and subscribe if you found my tutorials helpful :D
* Twitter: https://twitter.com/Devination3D
/*/
/*/edit by juan.amaral/*/
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FloatingPlayer2DController : MonoBehaviour
{



    private bool smooth;
    private float maxSpeed = 30;
    private float smoothTime = 0.3f;
    private Vector2 currentVelocity;


    private bool reduziu = false;

    public float moveForce = 30, boostMultiplier = 2;
    Rigidbody2D myBody;


    private float smoothX;
    private float smoothY;
    float count = 5;
    int limit = 0;
    bool contador = false;


    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myBody.velocity = Vector2.SmoothDamp(myBody.velocity, new Vector2(0, 0), ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);
        //Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
        //           CrossPlatformInputManager.GetAxis("Vertical"))
        //           * moveForce;
        //Vector3 lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_2"),
        //    CrossPlatformInputManager.GetAxis("Vertical_2"), 4096);









    }
    void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
           CrossPlatformInputManager.GetAxis("Vertical"))
           * moveForce;
        Vector3 lookVec = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_2"),
            CrossPlatformInputManager.GetAxis("Vertical_2"), 4096);

        if (JoystickMove.ClickMove)
        {
            bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
            myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));
            myBody.velocity = Vector2.SmoothDamp(myBody.velocity, new Vector2(0, 0), ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);

            JoystickMove.ClickMove = false;
        }
        //if (Input.touchCount > 0)
        //{
        //    var touch = Input.GetTouch(0);
        //    if (touch.position.x < Screen.width / 2)
        //    {
        //        //Debug.Log("Left click");
        //        Debug.Log("Left click" + moveForce);
        //        //moveForce = 5;
        //        //contador = true;
        //        bool isBoosting = CrossPlatformInputManager.GetButton("Boost");
        //        myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));
        //        myBody.velocity = Vector2.SmoothDamp(myBody.velocity, new Vector2(0, 0), ref currentVelocity, smoothTime, maxSpeed, Time.deltaTime);
        //        Debug.Log("entrou");
        //    }
        //    else if (touch.position.x > Screen.width / 2)
        //    {
        //        //Debug.Log("Right click");
        //    }
        //}





        if (lookVec.x != 0 && lookVec.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);

    }
}