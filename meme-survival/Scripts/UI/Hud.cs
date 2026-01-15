using Godot;

namespace MemeSurvival.Scripts.UI;

public partial class Hud : CanvasLayer
{
    [Export] private Control _gameOverMenu;
    
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
