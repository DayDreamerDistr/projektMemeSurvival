using Godot;

namespace MemeSurvival.Scripts.UI;

public partial class Hud : CanvasLayer
{
    [Export] private Control _gameOverMenu;
    
    public void TryAgainButtonPressed()
    {
        _gameOverMenu.Visible = false;
        GetTree().ChangeSceneToFile("res://Scenes/world.tscn");
    }

    public void PlayerDied()
    {
        _gameOverMenu.Visible = true;
    }
}
