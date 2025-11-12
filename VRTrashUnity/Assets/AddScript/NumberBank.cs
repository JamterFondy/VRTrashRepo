using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NumberBank", menuName = "Scriptable Objects/NumberBank")]
public class NumberBank : ScriptableObject
{
    public List<Number> NumberBankList = new List<Number>();
}

[System.Serializable]
public class Number
{
    public string NumberName = "Time";

    [SerializeField]
    public int MaxTime = 100;

}
