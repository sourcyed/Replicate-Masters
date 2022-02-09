using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum GateType
{
    Addition,
    Multiplication
}

public class Gate : MonoBehaviour
{
    [SerializeField] GateType type;
    [SerializeField] int value;
    public GameObject passage;
    public Collider pairGateCollider;

    public TextMeshPro gateText;

    private void Start()
    {
        string valueText = "";

        if (type == GateType.Addition)
        {
            valueText += "+";
        }
        else if (type == GateType.Multiplication)
        {
            valueText += "x";
        }

        valueText += value.ToString();

        gateText.text = valueText;
    }

    public int GetNewCount(int count)
    {
        int newCount = count;
        
        if (type == GateType.Addition)
        {
            newCount += value;
        }
        else if (type == GateType.Multiplication)
        {
            newCount *= value;
        }

        if (passage != null)
        {
            Destroy(passage);
            passage = null;
        }
        if (gateText != null)
        {
            Destroy(gateText);
            gateText = null;
        }

        if (pairGateCollider != null)
        {
            pairGateCollider.enabled = false;
        }

        return newCount;
    }
}

