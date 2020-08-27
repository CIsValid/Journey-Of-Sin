using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadChecker : MonoBehaviour
{
    public GameObject Camera;
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19)
            {
                print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }
        }


        if (Xbox_One_Controller == 1)
        {
            this.gameObject.GetComponent<PlayerController>().enabled = false;
            this.gameObject.GetComponent<PlayerControllerXbox>().enabled = true;
            this.gameObject.GetComponent<PlayerControllerPs4>().enabled = false;
            Camera.GetComponent<CameraControllerConsole>().enabled = true;
            Camera.GetComponent<CameraControllerPs>().enabled = false;
            Camera.GetComponent<CameraController>().enabled = false;
        }
        else if (PS4_Controller == 1)
        {
            this.gameObject.GetComponent<PlayerController>().enabled = false;
            this.gameObject.GetComponent<PlayerControllerXbox>().enabled = false;
            this.gameObject.GetComponent<PlayerControllerPs4>().enabled = true;
            Camera.GetComponent<CameraController>().enabled = false;
            Camera.GetComponent<CameraControllerConsole>().enabled = false;
            Camera.GetComponent<CameraControllerPs>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<PlayerController>().enabled = true;
            this.gameObject.GetComponent<PlayerControllerXbox>().enabled = false;
            this.gameObject.GetComponent<PlayerControllerPs4>().enabled = false;
            Camera.GetComponent<CameraControllerConsole>().enabled = false;
            Camera.GetComponent<CameraControllerPs>().enabled = false;
            Camera.GetComponent<CameraController>().enabled = true;

        }
    }
}
