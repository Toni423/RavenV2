using Godot;
using System;

public partial class testButton : Button {

	[Export] public Building building;
	public void testClick() {
		building.employ(new Raven());
		
	}
}

