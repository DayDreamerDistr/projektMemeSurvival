using Godot;

namespace MemeSurvival.Scripts.UI;

public partial class Hud : CanvasLayer
{
    [Export] private Control _gameOverMenu;
    [Export] private Label _scoreLabel;
    private Player _player;

    public override void _Ready()
    {
        _player = GetNode<Player>("../Player");
        _gameOverMenu.Visible = false;
    }

    public override void _Process(double delta)
    {
        //_scoreLabel.Text = "Score: " + _player.Score;
    }

    private void TryAgainButtonPressed()
    {
        _gameOverMenu.Visible = false;
        GetTree().ChangeSceneToFile("res://Scenes/world.tscn");
    }

    private void PlayerDied()
    {
        _gameOverMenu.Visible = true;
    }
}
