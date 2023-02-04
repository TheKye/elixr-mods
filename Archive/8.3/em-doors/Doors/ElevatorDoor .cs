namespace Eco.Mods.TechTree
{
    using Eco.EM.Components;
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
    using System.Collections.Generic;

    // [DoNotLocalize]

    [Serialized]
    [RequireComponent( typeof( PropertyAuthComponent ) )]
    [RequireComponent( typeof( SolidGroundComponent ) )]
    public partial class ElevatorDoorsObject : AutoDoors.AutoDoor
    { 
        public override LocString DisplayName { get { return Localizer.DoStr( "Elevator Door" ); } }

        protected override void Initialize() { }
        static ElevatorDoorsObject() {

            var BlockOccupancyList = new List<BlockOccupancy>();

            for (int z = 0; z <= 2; z++)
                for (int y = -2; y <= 1; y++)
                    BlockOccupancyList.Add(new BlockOccupancy(new Vector3i(0, z, y), typeof(BuildingWorldObjectBlock)));

            WorldObject.AddOccupancy<ElevatorDoorsObject>(BlockOccupancyList);
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
    public partial class ElevatorDoorsItem :
        WorldObjectItem<ElevatorDoorsObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr( "Elevator Door" ); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr( "A Set Of Elevator Doors. Can be locked for certain players." ); } }

        static ElevatorDoorsItem()
        {

        }

    }

    [RequiresSkill( typeof( ElectronicsSkill ), 2 )]
    public partial class ElevatorDoorsRecipe : Recipe
    {
        public ElevatorDoorsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<ElevatorDoorsItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<IronIngotItem>(typeof(ElectronicsSkill), 40, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<ScrewsItem>(typeof(ElectronicsSkill), 30, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<CircuitItem>(typeof(ElectronicsSkill), 10, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<ServoItem>(typeof(ElectronicsSkill), 2, ElectronicsSkill.MultiplicativeStrategy),
                new CraftingElement<CopperWiringItem>(typeof(ElectronicsSkill), 40, ElectronicsSkill.MultiplicativeStrategy),

            };
            this.ExperienceOnCraft = 20;
            this.CraftMinutes = CreateCraftTimeValue( typeof( ElevatorDoorsRecipe ), Item.Get<ElevatorDoorsItem>( ).UILink( ), 10, typeof( ElectronicsSkill ), typeof( ElectronicsFocusedSpeedTalent ), typeof( ElectronicsParallelSpeedTalent ) );
            this.Initialize( Localizer.DoStr( "Elevator Door" ), typeof( ElevatorDoorsRecipe ) );
            CraftingComponent.AddRecipe( typeof( ElectronicsAssemblyObject ), this );
        }
    }

}