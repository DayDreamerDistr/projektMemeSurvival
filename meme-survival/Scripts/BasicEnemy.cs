using System.Threading.Tasks;
using Godot;

namespace MemeSurvival.Scripts;
	
public partial class BasicEnemy : CharacterBody2D
{
	public Player PlayerChar;
	private ShaderMaterial _shaderMaterial;
	
	private float _speed = 150.0f;
	private int _damage = 20;
	private int _knockback = 2000;
	public int Health = 100;
	private bool _isDead;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// To do: Získat path k player
		PlayerChar = GetNode<Player>("../../Player");
		var sprite = GetNode<Sprite2D>("Sprite2D");
		_shaderMaterial = sprite.Material as ShaderMaterial;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (_isDead)
			return;
		
		var distance = PlayerChar.GlobalPosition - GlobalPosition;
		var direction = distance.Normalized();
		
		var velocity = direction * _speed;
		Velocity = velocity;

		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		if (Health <= 0)
			Die();

		if (_isDead)
			return;
	}

	// To do: Vytvořit signál pro Hitbox
	private void HitboxBodyEntered(Node2D body)
	{
		if (_isDead)
			return;
		
		if (body is not Player)
			return;
		
		var player = (Player)body; // Změníme typ body na třídu Player, abychom mohli použít metodu TakeDamage.
		player.TakeDamage(_damage);
		player.ProcessKnockback(GlobalPosition, _knockback);
	}
	
	public async Task FlashRed()
	{
		// Zapne shader flash
		_shaderMaterial.SetShaderParameter("active", true);

		// delay aby byl vidět flash
		await Task.Delay(100);

		// Vypne flash
		// Kontrola zda je instance stále platná (mohla být mezitím smazána)
		if (IsInstanceValid(this))
		{
			_shaderMaterial.SetShaderParameter("active", false);
		}
	}

	private void Die()
	{
		// Zvýší skóre hráče
		PlayerChar.Score++;
		
		// Momentálně je _isDead k ničemu, ale mohlo by se hodit kdybychom chtěli spustit třeba Death Animation
		_isDead = true;
		QueueFree();
	}
}
