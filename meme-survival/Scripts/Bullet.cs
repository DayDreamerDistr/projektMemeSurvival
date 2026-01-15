using Godot;
using System;

namespace MemeSurvival.Scripts;

public partial class Bullet : Area2D
{
    public Vector2 FiringDirection;
    public float MuzzleVelocity = 30f;
    private int _damage = 25;

    private void OnBodyEntered(Node2D body)
    {
        if (body is not CharEnemy1 enemy)
            return;
        
        enemy.Health -= _damage;
        QueueFree();
    }
}
