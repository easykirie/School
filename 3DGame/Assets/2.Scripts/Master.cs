using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : Character {

    

    public override void Method2()
    {
        base.Method2();
        Debug.Log(gameObject.name + "-Method2_Master Num2 : " + Num2);
    }

    


}
