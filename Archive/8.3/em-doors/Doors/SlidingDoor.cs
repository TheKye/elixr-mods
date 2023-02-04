namespace Eco.Mods.TechTree
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
    using System;
    using System.Collections.Generic;

    [Serialized]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    [RequireComponent( typeof( SolidGroundComponent ) )]
    public partial class SlidingDoorObject : AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Sliding Door" ); } }

        public virtual Type RepresentedItemType { get { return typeof( SlidingDoorItem ); } }

        protected override void Initialize() { }

        public override void Destroy() => base.Destroy( );

    }

    [Serialized]
    [ItemTier( 2 )]
    [Weight( 600 )]
    [MaxStackSize( 10 )]
    public partial class SlidingDoorItem :
        WorldObjectItem<SlidingDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Sliding Door" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A Sliding Glass Door. Can be locked for certain players." ); } }

        static SlidingDoorItem()
        {

        }    }

    [RequiresModule( typeof( KilnObject ) )]
    [RequiresSkill( typeof( GlassworkingSkill ), 4 )]
    public partial class SlidingDoorRecipe : Recipe
    {
        public SlidingDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<SlidingDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GreyGlassItem>(typeof(GlassworkingSkill), 10, GlassworkingSkill.MultiplicativeStrategy, typeof(GlassworkingLavishResourcesTalent)),
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 5, SmeltingSkill.MultiplicativeStrategy)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue( typeof( SlidingDoorRecipe ), Item.Get<SlidingDoorItem>( ).UILink( ), 10, typeof( GlassworkingSkill ), typeof( GlassworkingFocusedSpeedTalent ), typeof( GlassworkingParallelSpeedTalent ) );
            this.Initialize( Localizer.DoStr( "Sliding Door" ), typeof( SlidingDoorRecipe ) );
            CraftingComponent.AddRecipe( typeof( GlassworkingTableObject ), this );
        }
    }
}