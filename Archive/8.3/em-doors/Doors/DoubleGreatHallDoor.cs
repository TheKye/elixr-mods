namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.World.Blocks;
    // [DoNotLocalize]
    using System.Collections.Generic;

    [Serialized]
    [RequireComponent( typeof( OnOffComponent ) )]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    [RequireComponent( typeof( SolidGroundComponent ) )]
    public partial class DoubleGreatHallDoorObject :
        WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Double Great Hall Door" ); } }
        protected override void Initialize() { }
        static DoubleGreatHallDoorObject() {
            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int z = 0; z <= 5; z++)
                for (int y = -5; y <= 0; y++)
                    BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(0, z, y), typeof(BuildingWorldObjectBlock)));

            AddOccupancy<DoubleGreatHallDoorObject>(BlockOccupancyList);

        }

        public override void Destroy()
        {
            base.Destroy( );
        }

    }

    [Serialized]
    [ItemTier( 2 )]
    [Weight( 600 )]
    [MaxStackSize( 10 )]
    public partial class DoubleGreatHallDoorItem :
        WorldObjectItem<DoubleGreatHallDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Double Great Hall Door" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A Giant Set Of Doors For Decorative Halls. Can be locked for certain players." ); } }

        static DoubleGreatHallDoorItem()
        {


        }


    }

    [RequiresSkill( typeof( LumberSkill ), 4 )]
    public partial class DoubleGreatHallDoorRecipe : Recipe
    {
        public DoubleGreatHallDoorRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<DoubleGreatHallDoorItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LumberItem>(typeof(LumberSkill), 100, LumberSkill.MultiplicativeStrategy, typeof(LumberLavishResourcesTalent)),
                new CraftingElement<IronIngotItem>(typeof(SmeltingSkill), 30, SmeltingSkill.MultiplicativeStrategy)
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue( typeof( DoubleGreatHallDoorRecipe ), Item.Get<DoubleGreatHallDoorItem>( ).UILink( ), 25, typeof( LumberSkill ), typeof( LumberFocusedSpeedTalent ), typeof( LumberParallelSpeedTalent ) );
            this.Initialize( Localizer.DoStr( "Great Hall Door - Double" ), typeof( DoubleGreatHallDoorRecipe ) );
            CraftingComponent.AddRecipe( typeof( CarpentryTableObject ), this );
        }
    }

}