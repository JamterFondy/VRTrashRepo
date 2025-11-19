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
    [SerializeField]
    public int maxTime;
    public int MaxTime => maxTime;

    public int pointReset;
    public int PointReset => pointReset;

    public int petBottlePoint;
    public int PetBottlePoint => petBottlePoint;

    public int plasticPoint;
    public int PlasticPoint => plasticPoint;



}
