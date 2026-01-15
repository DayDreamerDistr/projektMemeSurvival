using Godot;
using System;
using System.Collections.Generic;

namespace MemeSurvival.Scripts;

public partial class BulletController : Node2D
{
    public override void _PhysicsProcess(double delta)
    {
        // Hromadné použití PhysicsProcess pro optimalizaci
        var children= GetChildren();
        List<Bullet> bullets = new();
        foreach (var child in children)
        {
            if  (child is Bullet bullet)
                bullets.Add(bullet);
        }

        foreach (var bullet in bullets)
        {
            bullet.GlobalPosition += bullet.FiringDirection * bullet.MuzzleVelocity;
        }
    }
}
