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
        
        // To do: přidat do podmínky Input pro shoot + zavolat výstřel
        if (_timeSinceLastShot >= _shootingDelay)
        {
            _timeSinceLastShot = 0;
        }
    }
    
    private void Shoot()
    {
        // Načte Scene ze souboru uloženého v BulletScenePath
        var bulletScene = GD.Load<PackedScene>(BulletScenePath);
        // Vytvoříme instanci třídy (scény)
        var bulletInstance = bulletScene.Instantiate<Bullet>();
        // Dáme instanci naši pozici a směr letu
        bulletInstance.GlobalPosition = GlobalPosition;
        bulletInstance.FiringDirection = (GetGlobalMousePosition() - GlobalPosition).Normalized();
        // Na závěr musíme instanci přidat jako potomka do struktury všech nodes
        _bulletController.AddChild(bulletInstance);
    }
}
