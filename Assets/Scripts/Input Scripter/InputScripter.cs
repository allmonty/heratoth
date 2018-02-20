using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class SimulatedInput
{
    public string name = "";
    public float duration = 0.0f;
    public float valueX = 0.0f;
    public float valueY = 0.0f;
    public float delay = 0.0f;
    public SimulatedInputOption option;
}

public enum SimulatedInputOption { Wait, Button, ButtonDown, Axis , AxisRaw, MousePos };

public class InputScripter: MonoBehaviour
{
    public List<SimulatedInput> simulatedInputs = new List<SimulatedInput>();

    bool waiting = false;

    void Start()
    {
        InputManager.isSimulatingMouse = true;
    }

    void OnDisable()
    {
        InputManager.isSimulatingMouse = false;
    }

    void Update()
    {
        compute();
    }

    void compute()
    {
        if (waiting) return;

        if(simulatedInputs.Count <= 0)
        {
            //Debug.Log("Input Scripter: Done!");
            enabled = false;
            return;
        }
        
        SimulatedInput nextInput = popSimulatedInput();

        switch (nextInput.option)
        {
            case SimulatedInputOption.Button:
                StartCoroutine("computeButton", nextInput);
                break;
            case SimulatedInputOption.ButtonDown:
                computeButtonDown(nextInput.name);
                break;
            case SimulatedInputOption.AxisRaw:
                StartCoroutine("computeAxisRaw", nextInput);
                break;
            case SimulatedInputOption.Axis:
                StartCoroutine("computeAxis", nextInput);
                break;
            case SimulatedInputOption.MousePos:
                computeMousePos(nextInput);
                break;
            case SimulatedInputOption.Wait:
                waiting = true;
                Invoke("resumeComputation", nextInput.duration);
                break;
            default:
                break;
        }
    }

    void resumeComputation()
    {
        waiting = false;
    }

    void computeButtonDown(string name)
    {
        InputManager.inputs[name] = 1f;
    }

    IEnumerator computeButton(SimulatedInput btn)
    {
        InputManager.inputs[btn.name] = 1f;
        yield return new WaitForSeconds(btn.duration);
        InputManager.inputs.Remove(btn.name);
    }

    IEnumerator computeAxisRaw(SimulatedInput btn)
    {
        InputManager.inputs[btn.name] = btn.valueX;
        yield return new WaitForSeconds(btn.duration);
        InputManager.inputs.Remove(btn.name);
    }

    IEnumerator computeAxis(SimulatedInput btn)
    {
        float waitAfterDelay = Mathf.Abs(btn.duration - btn.delay);
        float velocity = 1f / btn.delay;
        float timer = 0.0f;

        InputManager.inputs[btn.name] = btn.valueX;

        while (timer < btn.delay)
        {
            timer += Time.deltaTime;
            InputManager.inputs[btn.name] = (timer * velocity) * btn.valueX;
            yield return null;
        }
        
        yield return new WaitForSeconds(waitAfterDelay);
        InputManager.inputs.Remove(btn.name);
    }

    void computeMousePos(SimulatedInput btn)
    {
        InputManager.simulatedMousePos = new Vector3(btn.valueX, btn.valueY, 0f);
    }

    public void addNewSimulatedInput()
    {
        simulatedInputs.Add(new SimulatedInput());
    }

    public void removeSimulatedInput(int index)
    {
        simulatedInputs.RemoveAt(index);
    }

    public SimulatedInput popSimulatedInput()
    {
        SimulatedInput head = simulatedInputs[0];
        removeSimulatedInput(0);
        return head;
    }

    public void moveSimulatedInputUp(int index)
    {
        if(index > 0)
        {
            SimulatedInput value = simulatedInputs[index];
            simulatedInputs.RemoveAt(index);
            simulatedInputs.Insert(index - 1, value);
        }
    }

    public void moveSimulatedInputDown(int index)
    {
        if (index < simulatedInputs.Count - 1)
        {
            SimulatedInput value = simulatedInputs[index];
            simulatedInputs.RemoveAt(index);
            simulatedInputs.Insert(index + 1, value);
        }
    }

    public void stopSimulation(){
        InputManager.inputs.Clear();
    }
}
