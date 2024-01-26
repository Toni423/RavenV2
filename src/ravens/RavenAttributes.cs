using Godot;
using System;
using System.Collections.Generic;


public partial class RavenAttributes : Node
{
    public enum types {
        Strength, 
        Dexterity, 
        Constitution, 
        Intelligence, 
        Perception, 
        Crafting
    }

    private readonly Dictionary<types, RavenAttribute> attributes = new (6);

    public RavenAttributes() {
        attributes.Add(types.Strength, new RavenAttribute(types.Strength));
        attributes.Add(types.Dexterity, new RavenAttribute(types.Dexterity));
        attributes.Add(types.Constitution, new RavenAttribute(types.Constitution));
        attributes.Add(types.Intelligence, new RavenAttribute(types.Intelligence));
        attributes.Add(types.Perception, new RavenAttribute(types.Perception));
        attributes.Add(types.Crafting, new RavenAttribute(types.Crafting));
    }

    public void levelUp(types type) {
        attributes[type].levelUp();
    }

    public int getAttributeLevel(types type) {
        return attributes[type].getLevel();
    }
}
