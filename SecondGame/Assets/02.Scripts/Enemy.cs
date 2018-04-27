using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character {

    public int Damage = 10;

    protected IState state;

    protected Dictionary<string, IState> states = new Dictionary<string, IState>();

    public abstract void Setup();

    public override void OnHurt(int amount)
    {
        base.OnHurt(amount);

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<Character>().OnHurt(Damage);
    }

    public void AddState(string key, IState state)
    {
        if (states.ContainsKey(key) == false)
            states.Add(key, state);
    }

    public IState GetState(string key)
    {
        if (states.ContainsKey(key))
            return states[key];

        return null;        
    }

    public void ChangeState(string key)
    {
        if (state != null && state.IsRunning)
            state.Exit();

        state = GetState(key);
    }

    protected virtual void Update()
    {
        if (state == null || state.UseFixedUpdate)
            return;

        if (!state.IsRunning)
            state.Enter();

        state.Update();
    }

    protected virtual void FixedUpdate()
    {
        if (state == null || state.UseFixedUpdate == false)
            return;

        if (!state.IsRunning)
            state.Enter();

        state.Update();
    }

    private void Awake()
    {
        Setup();
    }
}
