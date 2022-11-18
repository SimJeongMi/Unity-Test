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
                print("isHarin Ture");
                print("안녕 난 하린이야");
            }
            if (isJeongMi)
            {
                print("isJeongMi True");
<<<<<<< Updated upstream
                print("참으로 눌렸다ㅏㅏ");
=======
                print(" 나는 정미");
>>>>>>> Stashed changes
            }
        }
    }
}
