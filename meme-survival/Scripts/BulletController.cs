using Godot;
using System;
using System.Collections.Generic;

namespace MemeSurvival.Scripts;

public partial class BulletController : Node2D
{
    public override void _PhysicsProcess(double delta)
    {
        // Hromadné použití PhysicsProcess pro optimalizaci
        
        // Získá všechny bullets co zrovna existují
        var children= GetChildren();
        List<Bullet> bullets = new();
        foreach (var child in children)
        {
            // Konverze na typ bullet (GetChildren získá všechno jako typ Node)
            if  (child is Bullet bullet)
                bullets.Add(bullet);
        }

        // Aktualizace pozice na základě proměnných pro každý bullet individuálně
        foreach (var bullet in bullets)
        {
            bullet.GlobalPosition += bullet.FiringDirection * bullet.MuzzleVelocity;
        }
    }
}
