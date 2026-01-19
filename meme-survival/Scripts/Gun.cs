using Godot;
using System;

namespace MemeSurvival.Scripts;

public partial class Gun : Node2D
{
    [Export] private float _shootingDelay;
    private BulletController _bulletController;
    private Player _player;
    // Super simple timer
    private double _timeSinceLastShot;
    private const string BulletScenePath = "res://Scenes/bullet.tscn";

    public override void _Ready()
    {
        _bulletController = GetNode<BulletController>("../../BulletController");
        _player = GetParent<Player>();
    }
    
    public override void _Process(double delta)
    {
        /*if (_player.IsDead)
            return;*/
        
        // Jednoduchý způsob jak udělat, aby se node rotovala na určitý bod
        LookAt(GetGlobalMousePosition());
        
        // Delta = čas v sekundách mezi jednotlivými frames (nižší framerate => větší delta)
        _timeSinceLastShot += delta;
        
        // To do: přidat Input pro shoot
        if (Input.IsActionJustPressed("shoot") && _timeSinceLastShot >= _shootingDelay)
        {
            Shoot();
            _timeSinceLastShot = 0;
        }
    }

    private void Shoot()
    {
        var bulletScene = GD.Load<PackedScene>(BulletScenePath);
        var bulletInstance = bulletScene.Instantiate<Bullet>();
        bulletInstance.GlobalPosition = GlobalPosition;
        bulletInstance.FiringDirection = (GetGlobalMousePosition() - GlobalPosition).Normalized();
        _bulletController.AddChild(bulletInstance);
    }
}
