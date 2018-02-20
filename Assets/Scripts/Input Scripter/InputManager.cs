using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : ScriptableObject {

    public static Dictionary<string, float> inputs = new Dictionary<string, float>();

    public static Vector3 simulatedMousePos = Vector3.zero;
    public static bool isSimulatingMouse = false;
    public static Vector3 mousePosition
    {
        get
        {
            if (isSimulatingMouse)
            {
                return simulatedMousePos;
            }
            else
            {
                return Input.mousePosition;
            }
        }
    }

    public static bool getButton(string name)
    {
        if(Input.GetButton(name) || inputs.ContainsKey(name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool getButtonDown(string name)
    {
        if (Input.GetButtonDown(name) || inputs.ContainsKey(name))
        {
            inputs.Remove(name);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static float getAxisRaw(string name)
    {
        if (Input.GetAxisRaw(name) != 0f)
        {
            return Input.GetAxisRaw(name);
        }
        else if (inputs.ContainsKey(name))
        {
            return inputs[name];
        }
        else
        {
            return 0f;
        }
    }

    public static float getAxis(string name)
    {
        if (Input.GetAxis(name) != 0f)
        {
            return Input.GetAxis(name);
        }
        else if (inputs.ContainsKey(name))
        {
            return inputs[name];
        }
        else
        {
            return 0f;
        }
    }
}
