using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(InputScripter))]
[CanEditMultipleObjects]
public class Editor_InputScripter : Editor {

    private InputScripter it;

    string[] inputOptions = new string[]
    {
        "Wait", "Button", "ButtonDown", "Axis", "AxisRaw", "MousePos"
    };

    void OnEnable()
    {
        it = target as InputScripter;
    }

    public override void OnInspectorGUI()
    {
        Undo.RecordObject(target, "An attribute of the input simulator was modified");

        plotHeader();

        for(int i = 0; i < it.simulatedInputs.Count; i++)
        {
            plotSimulatedInput(i);
        }
    }

    void plotHeader()
    {
        GUILayout.BeginHorizontal("box");

        GUILayout.Label("Total Inputs: " + it.simulatedInputs.Count);

        if (GUILayout.Button("New"))
        {
            Undo.RecordObject(target, "Added new input in the input simulator");
            it.addNewSimulatedInput();
        }

        GUILayout.EndHorizontal();
    }

    void plotSimulatedInput(int i)
    {
        GUILayout.BeginVertical("box");

        plotSimulatedInputHeader(i);

        switch (it.simulatedInputs[i].option)
        {
            case SimulatedInputOption.Wait:
                plotWaitOption(i);
                break;
            case SimulatedInputOption.Button:
                plotButtonOption(i);
                break;
            case SimulatedInputOption.ButtonDown:
                plotButtonDownOption(i);
                break;
            case SimulatedInputOption.Axis:
                plotAxisOption(i);
                break;
            case SimulatedInputOption.AxisRaw:
                plotAxisRawOption(i);
                break;
            case SimulatedInputOption.MousePos:
                plotMousePosOption(i);
                break;
            default:
                break;
        }

        GUILayout.EndVertical();
    }

    private void plotWaitOption(int i)
    {
        plotFloatRaw(i, ref it.simulatedInputs[i].duration, "Duration:");
    }

    private void plotButtonOption(int i)
    {
        plotString(i, ref it.simulatedInputs[i].name, "Name:");
        plotFloatRaw(i, ref it.simulatedInputs[i].duration, "Duration:");
    }

    private void plotButtonDownOption(int i)
    {
        plotString(i, ref it.simulatedInputs[i].name, "Name:");
    }

    private void plotAxisOption(int i)
    {
        plotString(i, ref it.simulatedInputs[i].name, "Name:");
        plotFloatRaw(i, ref it.simulatedInputs[i].valueX, "Value:");
        plotFloatRaw(i, ref it.simulatedInputs[i].duration, "Duration:");
        plotFloatRaw(i, ref it.simulatedInputs[i].delay, "Delay:");
    }

    private void plotAxisRawOption(int i)
    {
        plotString(i, ref it.simulatedInputs[i].name, "Name:");
        plotFloatRaw(i, ref it.simulatedInputs[i].valueX, "Value:");
        plotFloatRaw(i, ref it.simulatedInputs[i].duration, "Duration:");
    }

    private void plotMousePosOption(int i)
    {
        plotFloatRaw(i, ref it.simulatedInputs[i].valueX, "Pos X:");
        plotFloatRaw(i, ref it.simulatedInputs[i].valueY, "Pos Y:");
    }

    void plotSimulatedInputHeader(int i)
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Simulated Input:", GUILayout.ExpandWidth(true));
        it.simulatedInputs[i].option = (SimulatedInputOption)EditorGUILayout.Popup((int)it.simulatedInputs[i].option, inputOptions, GUILayout.Width(Screen.width * 0.35f));
        if (GUILayout.Button("/\\", GUILayout.Width(Screen.width * 0.05f)))
        {
            it.moveSimulatedInputUp(i);
            return;
        }
        if (GUILayout.Button("\\/", GUILayout.Width(Screen.width * 0.05f)))
        {
            it.moveSimulatedInputDown(i);
            return;
        }
        if (GUILayout.Button("X", GUILayout.Width(Screen.width * 0.05f)))
        {
            it.removeSimulatedInput(i);
            return;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }

    void plotString(int i, ref string value, string label)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.ExpandWidth(true));
        value = GUILayout.TextField(value, GUILayout.Width(Screen.width * 0.5f));
        GUILayout.EndHorizontal();
    }

    void plotFloatRaw(int i, ref float value, string label)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.ExpandWidth(true));
        value = EditorGUILayout.FloatField(value, GUILayout.Width(Screen.width * 0.5f));
        GUILayout.EndHorizontal();
    }

    void plotFloatSlider(int i, float value, float min, float max, string label)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(label, GUILayout.ExpandWidth(true));
        value = EditorGUILayout.Slider(value, -1f, 1f, GUILayout.Width(Screen.width * 0.5f));
        GUILayout.EndHorizontal();
    }
}
