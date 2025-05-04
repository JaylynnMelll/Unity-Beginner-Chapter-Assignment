using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    // [Fields]
    private string _name;
    protected string Name { get; set; }

    private int _level;
    protected int Level { get; set; }

    private int _hp;
    [SerializeField] protected int Hp { get; set; }

    private int _maxHp;
    [SerializeField] protected int MaxHp { get; set; }

    private int _mp;
    [SerializeField] protected int Mp { get; set; }

    private int _maxMp;
    [SerializeField] protected int MaxMp { get; set; }

    private int _attackPower;
    [SerializeField] protected int AttackPower { get; set; }

    private int _defensePower;
    [SerializeField] protected int DefensePower { get; set; }

    private int _speed;
    [SerializeField] protected float Speed { get; set; } = 3;

    // [Methods]
    public virtual void InitCharacter(string name)
    {
        Name = name;
    }

    public virtual void Movement()
    {
        // Implement movement logic here
    }
}
