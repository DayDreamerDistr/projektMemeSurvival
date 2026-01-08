using Godot;
using System;

namespace MemeSurvival.Scripts.Util;

public partial class EnemySpawner : Node2D
{
    [Export] private Player _player;
    
    private Random _rdm = new();
    public void TimerTick()
    {
        var spawnPos = _player.GlobalPosition;
        spawnPos.X += _rdm.Next(-100, 100);
        spawnPos.Y += _rdm.Next(-100, 100);
        
        PackedScene enemyScene = GD.Load<PackedScene>("res://Scenes/BasicEnemy.tscn");
        CharEnemy1 enemyInstance = enemyScene.Instantiate<CharEnemy1>();
        enemyInstance.Player = _player;
        AddChild(enemyInstance);
    }
}
