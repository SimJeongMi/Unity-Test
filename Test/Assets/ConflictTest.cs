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
                print("�ȳ� �� �ϸ��̾�");
            }
            if (isJeongMi)
            {
                print("isJeongMi True");
<<<<<<< Updated upstream
                print("������ ���ȴ٤���");
=======
                print(" ���� ����");
>>>>>>> Stashed changes
            }
        }
    }
}
