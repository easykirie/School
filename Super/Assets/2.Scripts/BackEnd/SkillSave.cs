using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSave : MonoBehaviour {
    public Test test;

    public Skill Fire = new Skill(0, "Fire");
    public Skill Ice = new Skill(1, "Ice");
    public Skill Earth = new Skill(2, "Earth");
    public Skill Water = new Skill(3, "Water");
    // Use this for initialization
    void Start () {
        test.SkillSave(Fire);
        test.SkillSave(Ice);
        test.SkillSave(Earth);
        test.SkillSave(Water);

        test.JsonStart();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
