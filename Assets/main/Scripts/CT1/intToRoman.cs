using System.Collections.Generic;
using UnityEngine;

public class intToRoman : MonoBehaviour
{
    public static intToRoman instance;
    private List<int> arabic = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    private List<string> roman = new List<string>() { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
    private string result = "";
    
    public string int2roman(int value)
    {
        result = "";
        for (int i = 0; i < 13; i++)
        {
            while (value >= arabic[i])
            {
                result = result + roman[i].ToString();
                value = value - arabic[i];
            }
        }
        return result;
    }

    private void Awake()
    {
        instance = this;
    }
}
