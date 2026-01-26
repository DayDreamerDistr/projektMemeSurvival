using Godot;
using System;

namespace MemeSurvival.Scripts;

public partial class Gun : Node2D
{
    private Player _player;

    public override void _Ready()
    {
        // Získá BulletController skrz relativní cestu od hráče
        //_bulletController = GetNode<BulletController>("../../BulletController");
        _player = GetParent<Player>();
    }
    
    public override void _Process(double delta)
    {
        // Delta = čas v sekundách mezi jednotlivými frames (nižší framerate => větší delta)
        
        // To do: přidat podmínky Input a shoot + zavolat výstřel
    }
    
    private void Shoot()
    {
        // Načte Scene ze souboru uloženého v BulletScenePath
        //var bulletScene = GD.Load<PackedScene>(BulletScenePath);
        // Vytvoříme instanci třídy (scény)
        //var bulletInstance = bulletScene.Instantiate<Bullet>();
        // Dáme instanci naši pozici a směr letu
        //bulletInstance.GlobalPosition = GlobalPosition;
        //bulletInstance.FiringDirection = (GetGlobalMousePosition() - GlobalPosition).Normalized();
        // Na závěr musíme instanci přidat jako potomka do struktury všech nodes
        //_bulletController.AddChild(bulletInstance);
    }
}
