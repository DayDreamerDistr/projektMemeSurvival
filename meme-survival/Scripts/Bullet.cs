using Godot;
using System;

namespace MemeSurvival.Scripts;

public partial class Bullet : Area2D
{
    public Vector2 FiringDirection;
    public float MuzzleVelocity = 30f;
    private int _damage = 25;

    private async void OnBodyEntered(Node2D body)
    {
        if (body is not BasicEnemy enemy)
            return;
        
        enemy.Health -= _damage;
        await enemy.FlashRed();
        QueueFree();
    }
}
