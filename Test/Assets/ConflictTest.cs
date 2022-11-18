using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConflictTest : MonoBehaviour
{
    public bool isHarin;
    public bool isJeongMi;

    int Count;

    void Update()
    {
        Count++;
        if (Count >= 2)
        {
            TestStart(true);
        }
    }

    void TestStart(bool _TestStart)
    {
        if (_TestStart)
        {
            if (isHarin)
            {
                print("isHarin True");
            }
            if (isJeongMi)
            {
                print("isJeongMi True");
                print("충돌해결");
            }
        }
    }
}
