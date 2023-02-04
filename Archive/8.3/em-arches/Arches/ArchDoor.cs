namespace Eco.Mods.TechTree
{
    // [DoNotLocalize]
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.EM.Components;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.DynamicValues;

    #region Mortared Stone Door

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class ArchDoorObject : AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Mortaredstone Arch Door"); } }


        protected override void Initialize()
        {

        }

        static ArchDoorObject()
        {
            WorldObject.AddOccupancy<ArchDoorObject>(new List<BlockOccupancy>()
            {
               new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [Weight(6000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(HammerItem))]
    public partial class ArchDoorItem :
        WorldObjectItem<ArchDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Mortaredstone Arch Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Giant Door In The Arch. Can be locked for certain players."); } }

        static ArchDoorItem()
        {

        }


    }

    [RequiresSkill(typeof(MasonrySkill), 4)]
    public partial class ArchDoorRecipe : RecipeFamily
    {
        public ArchDoorRecipe()
        {
            this.Initialize(Localizer.DoStr("Arch Door- Mortaredstone"), typeof(ArchDoorRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ArchDoor",
                    Localizer.DoStr("Arch Door - Moraredstone"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(MortaredStoneItem),  70, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    new IngredientElement(typeof(MortarItem),  30, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<ArchDoorItem>(),
                    }
                )
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(ArchDoorRecipe), Item.Get<ArchDoorItem>().UILink(), 10, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Arch Door- Mortaredstone"), typeof(ArchDoorRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Stone Arch door
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class StoneArchDoorObject : AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stone Arch Door"); } }


        protected override void Initialize()
        {

        }

        static StoneArchDoorObject()
        {
            WorldObject.AddOccupancy<StoneArchDoorObject>(new List<BlockOccupancy>()
            {
               new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [Weight(6000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(HammerItem))]
    public partial class StoneArchDoorItem :
        WorldObjectItem<StoneArchDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Stone Arch Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Giant Door In The Arch. Can be locked for certain players."); } }

        static StoneArchDoorItem()
        {

        }


    }

    [RequiresSkill(typeof(MasonrySkill), 4)]
    public partial class StoneArchDoorRecipe : RecipeFamily
    {
        public StoneArchDoorRecipe()
        {
            this.Initialize(Localizer.DoStr("Arch Door - Stone"), typeof(StoneArchDoorRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ArchDoor",
                    Localizer.DoStr("Arch Door - Stone"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Stone",  70, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    new IngredientElement(typeof(MortarItem),  30, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<StoneArchDoorItem>(),
                    }
                )
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(StoneArchDoorRecipe), Item.Get<StoneArchDoorItem>().UILink(), 10, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Arch Door - Stone"), typeof(StoneArchDoorRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Sandstone

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class SandstoneArchDoorObject : AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Sandstone Arch Door"); } }


        protected override void Initialize()
        {

        }

        static SandstoneArchDoorObject()
        {
            WorldObject.AddOccupancy<SandstoneArchDoorObject>(new List<BlockOccupancy>()
            {
               new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [Tier(1)]
    [Weight(6000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(HammerItem))]
    public partial class SandstoneArchDoorItem :
        WorldObjectItem<SandstoneArchDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Sandstone Arch Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Giant Door In The Arch. Can be locked for certain players."); } }

        static SandstoneArchDoorItem()
        {

        }


    }

    [RequiresSkill(typeof(MasonrySkill), 4)]
    public partial class SandstoneArchDoorRecipe : RecipeFamily
    {
        public SandstoneArchDoorRecipe()
        {
            this.Initialize(Localizer.DoStr("Arch Door - SandStone"), typeof(SandstoneArchDoorRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ArchDoor",
                    Localizer.DoStr("Arch Door - SandStone"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(MortaredSandstoneItem),  70, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    new IngredientElement(typeof(MortarItem),  30, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<SandstoneArchDoorItem>(),
                    }
                )
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(SandstoneArchDoorRecipe), Item.Get<SandstoneArchDoorItem>().UILink(), 10, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Arch Door- Sandstone"), typeof(SandstoneArchDoorRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Granite
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class GraniteArchDoorObject : AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Granite Arch Door"); } }


        protected override void Initialize()
        {

        }

        static GraniteArchDoorObject()
        {
            WorldObject.AddOccupancy<GraniteArchDoorObject>(new List<BlockOccupancy>()
            {
               new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [Weight(6000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(HammerItem))]
    public partial class GraniteArchDoorItem :
        WorldObjectItem<GraniteArchDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Granite Arch Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Giant Door In The Arch. Can be locked for certain players."); } }

        static GraniteArchDoorItem()
        {

        }


    }

    [RequiresSkill(typeof(MasonrySkill), 4)]
    public partial class GraniteArchDoorRecipe : RecipeFamily
    {
        public GraniteArchDoorRecipe()
        {
            this.Initialize(Localizer.DoStr("Arch Door - Granite"), typeof(StoneArchDoorRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ArchDoor",
                    Localizer.DoStr("Arch Door - Granite"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(MortaredGraniteItem),  70, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    new IngredientElement(typeof(MortarItem),  30, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<GraniteArchDoorItem>(),
                    }
                )
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(GraniteArchDoorRecipe), Item.Get<GraniteArchDoorItem>().UILink(), 10, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Arch Door - Granite"), typeof(GraniteArchDoorRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
    #region Limestone
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class LimestoneArchDoorObject : AutoDoors.AutoDoor
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Limestone Arch Door"); } }


        protected override void Initialize()
        {

        }

        static LimestoneArchDoorObject()
        {
            WorldObject.AddOccupancy<LimestoneArchDoorObject>(new List<BlockOccupancy>()
            {
               new BlockOccupancy(new Vector3i(0, 0, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 0, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 1, 2), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 1), typeof(BuildingWorldObjectBlock)),
               new BlockOccupancy(new Vector3i(0, 2, 2), typeof(BuildingWorldObjectBlock)),
            });
        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    [Tier(1)]
    [Weight(6000)]
    [MaxStackSize(10)]
    [RequiresTool(typeof(HammerItem))]
    public partial class LimestoneArchDoorItem :
        WorldObjectItem<LimestoneArchDoorObject>
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Limestone Arch Door"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("A Giant Door In The Arch. Can be locked for certain players."); } }

        static LimestoneArchDoorItem()
        {

        }


    }

    [RequiresSkill(typeof(MasonrySkill), 4)]
    public partial class LimestoneArchDoorRecipe : RecipeFamily
    {
        public LimestoneArchDoorRecipe()
        {
            this.Initialize(Localizer.DoStr("Arch Door - Limestone"), typeof(StoneArchDoorRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ArchDoor",
                    Localizer.DoStr("Arch Door - Limestone"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(MortaredLimestoneItem),  70, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    new IngredientElement(typeof(MortarItem),  30, typeof(MasonrySkill), typeof(MultiplicativeStrategy)),
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<LimestoneArchDoorItem>(),
                    }
                )
            };
            this.ExperienceOnCraft = 2;
            this.CraftMinutes = CreateCraftTimeValue(typeof(LimestoneArchDoorRecipe), Item.Get<LimestoneArchDoorItem>().UILink(), 10, typeof(MasonrySkill), typeof(MasonryFocusedSpeedTalent), typeof(MasonryParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Arch Door - Limestone"), typeof(LimestoneArchDoorRecipe));
            CraftingComponent.AddRecipe(typeof(MasonryTableObject), this);
        }
    }
    #endregion
}