using Godot;
using System;

namespace MemeSurvival.Scripts.Util;

public partial class EnemySpawner : Node2D
{
    [Export] private Player _player;
    private const string EnemyScenePath = "res://Scenes/BasicEnemy.tscn";
    
    private void TimerTick()
    {
        if (_player.IsDead)
            return;
        
        // Zaručíme, že se nespawne moc enemies
        var enemies = GetChildren();
        if (enemies.Count > 100)
            return;
        
        var spawnPos = _player.GlobalPosition;
        spawnPos.X += Random.Shared.Next(-10, 10) * 50;
        spawnPos.Y += Random.Shared.Next(-10, 10) * 50;
        
        PackedScene enemyScene = GD.Load<PackedScene>(EnemyScenePath);
        BasicEnemy enemyInstance = enemyScene.Instantiate<BasicEnemy>();
        enemyInstance.PlayerChar = _player;
        enemyInstance.GlobalPosition = spawnPos;
        AddChild(enemyInstance);
    }
}
