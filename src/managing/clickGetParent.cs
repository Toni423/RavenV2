using Godot;
using System;

public partial class clickGetParent : Area2D {
	private bool mouseOver = false;
	private Inventory inventory;
	
	public override void _Ready() {
		inventory = (Inventory) GetTree().Root.GetChild(0).FindChild("Inventory");
		if (inventory == null) {
			GD.PushWarning("No inventory found!");
		}
	}
	
	
	private void _on_mouse_entered() {
		mouseOver = true;
	}


	private void _on_mouse_exited() {
		mouseOver = false;
	}

	public override void _Process(double delta) {
		if (!mouseOver) {
			return;
		}

		if (Input.IsActionJustPressed("LeftClick")) {
			inventory.clickedOn(GetParent());
		}
	}
}



