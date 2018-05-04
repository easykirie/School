using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    int Num1 = 0;

    public int Num2 = 0;

    void Method1()
    {
        Debug.Log(gameObject.name + "-Method1 Num1 : " + Num1);
        Debug.Log(gameObject.name + "-Method1 Num2 : " + Num2);
    }

    public virtual void Method2()
    {
        Debug.Log(gameObject.name + "-Method2 Num1 : " + Num1);
        Debug.Log(gameObject.name + "-Method2 Num2 : " + Num2);
    }

    public void Method3()
    {
        Debug.Log(gameObject.name + "-Method3 Num1 : " + Num1);
        Debug.Log(gameObject.name + "-Method3 Num2 : " + Num2);
    }

}
