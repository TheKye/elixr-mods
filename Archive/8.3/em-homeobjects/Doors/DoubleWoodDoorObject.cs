namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.EM.Components;
    using Eco.Gameplay.Wires;
    using Eco.Shared.Networking;

    [Serialized]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    public partial class DoubleWoodDoorObject : AutoDoors.AutoDoor
    {

        public override LocString DisplayName { get { return Localizer.DoStr( "Double Wood Door" ); } }

        public virtual Type RepresentedItemType { get { return typeof( DoubleWoodDoorItem ); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy( );

    }

    [Serialized]
    [ItemTier( 2 )]
    [Weight( 600 )]
    public partial class DoubleWoodDoorItem :
        WorldObjectItem<DoubleWoodDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Double Wood Door" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A Double Wooden Door." ); } }

        static DoubleWoodDoorItem()
        {

        }
    }

    [RequiresSkill( typeof( HewingSkill ), 0 )]
    public class DoubleWoodDoorRecipe : Recipe
    {
        public DoubleWoodDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
            new CraftingElement<DoubleWoodDoorItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
            new CraftingElement<LogItem>(typeof(HewingSkill), 12, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),
            new CraftingElement<GlassItem>(typeof(HewingSkill), 4, HewingSkill.MultiplicativeStrategy, typeof(HewingLavishResourcesTalent)),
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue( typeof( DoubleWoodDoorRecipe ), Item.Get<DoubleWoodDoorItem>( ).UILink( ), 10, typeof( HewingSkill ), typeof( HewingFocusedSpeedTalent ), typeof( HewingParallelSpeedTalent ) );
            this.Initialize( Localizer.DoStr( "Double Wood Door" ), typeof( DoubleWoodDoorRecipe ) );
            CraftingComponent.AddRecipe( typeof( CarpentryTableObject ), this );
        }
    }

}