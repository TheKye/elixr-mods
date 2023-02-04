5namespace Eco.Mods.TechTree
{
    using Eco.EM.Components;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Gameplay.Wires;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Networking;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World.Blocks;
    // [DoNotLocalize]
    using System.Collections.Generic;

    [Serialized]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    [RequireComponent( typeof( SolidGroundComponent ) )]
    public partial class GreatHallDoorObject : AutoDoors.LAutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Great Hall Door" ); } }
        protected override void Initialize() { }
        static GreatHallDoorObject() { }

        public override void Destroy()
        {
            base.Destroy( );
        }

    }

    [Serialized]
    [Weight( 600 )]
    [MaxStackSize( 10 )]
    public partial class GreatHallDoorItem : WorldObjectItem<GreatHallDoorObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A Giant Door For Decorative Halls. Can be locked for certain players." ); } }

        static GreatHallDoorItem()
        {

        }
    }

    [RequiresSkill( typeof( LumberSkill ), 4 )]
    public partial class GreatHallDoorRecipe : Recipe
    {
        public GreatHallDoorRecipe()
        {
            Products = new CraftingElement[]
            {
                new CraftingElement<GreatHallDoorItem>(),
            };

            Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberSkill), 100, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 30, SmeltingSkill.MultiplicativeStrategy)
            };
            ExperienceOnCraft = 2;
            CraftMinutes = CreateCraftTimeValue( typeof( GreatHallDoorRecipe ), Item.Get<GreatHallDoorItem>( ).UILink( ), 25, typeof( LumberSkill ), typeof( LumberFocusedSpeedTalent ), typeof( LumberParallelSpeedTalent ) );
            Initialize( Localizer.DoStr( "Great Hall Door" ), typeof( GreatHallDoorRecipe ) );
            CraftingComponent.AddRecipe( typeof( CarpentryTableObject ), this );
        }
    }
}