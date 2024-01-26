using Godot;
using System;

public partial class GatherersHut : Building {
    private int multiplier = 3;
    
    protected override void work(double delta) {
        for (int i = 0; i < employed.Count; i++) {
            float averageSkill = ((float)employed[i].attributes.getAttributeLevel(RavenAttributes.types.Intelligence) +
                                  (float)employed[i].attributes.getAttributeLevel(RavenAttributes.types.Perception)) /
                                 2.0f;
            inventory.addRessource(Inventory.ressourceTypes.worms, (int) (averageSkill * multiplier));
            GD.Print("Gathered: " + (int) (averageSkill * multiplier));
        }
    }
}
