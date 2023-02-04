namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Serialization;
    using Eco.Shared.Math;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Rooms;
    using Eco.Shared.Networking;
    using Eco.Shared.Utils;

    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class EMFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elixr Mods Flag"); } }
        protected override void Initialize()
        {

        }

        public override void Destroy()
        {
            base.Destroy();
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
        }

        public void CheckRoom(WorldObject flag, float range = 1f)
        {
            var objRoom = RoomData.Obj.GetNearestRoom(flag.Position);
            NetObjectManager
              .GetObjectsWithin(flag.Position.XYZi, range)
              .ForEach(obj =>
              {
                  WorldObject wo = obj as WorldObject;
                  if (wo != null && objRoom.RoomStats.Contained == true)
                  {
                      flag.SetAnimatedState("Enabled", true);
                  }
                  if (wo != null && objRoom.RoomStats.Contained == false)
                  {
                      flag.SetAnimatedState("Enabled", false);
                  }
              });
        }

        public override void Tick()
        {
            CheckRoom(this);
        }

    }

    [Serialized]
    [LocDisplayName("Elixr Mods Flag")]
    [Ecopedia("Flags", "Mod Flags", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(10)]
    public partial class EMFlagItem : WorldObjectItem<EMFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The Elixr Mods flag on a beautifuly hand crafted piece of cloth held up by a well crafted iron stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static EMFlagItem()
        {
            WorldObject.AddOccupancy<EMFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class EMFlagRecipe :
RecipeFamily
    {
        public EMFlagRecipe()
        {
            this.Initialize(Localizer.DoStr("Flag - Elixr Mods"), typeof(EMFlagRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Flag - Elixr Mods",
                    Localizer.DoStr("Flag - Elixr Mods"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<EMFlagItem>(),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Flag - Elixr Mods"), typeof(EMFlagRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }
}

namespace Eco.Mods.TechTree
{
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Serialization;
    using Eco.Shared.Math;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Rooms;
    using Eco.Shared.Networking;
    using Eco.Shared.Utils;

    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class EMRWFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Elixr Mods Flag Wood"); } }
        protected override void Initialize()
        {

        }

        public override void Destroy()
        {
            base.Destroy();
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();
        }

        public void CheckRoom(WorldObject flag, float range = 1f)
        {
            var objRoom = RoomData.Obj.GetNearestRoom(flag.Position);
            NetObjectManager
              .GetObjectsWithin(flag.Position.XYZi, range)
              .ForEach(obj =>
              {
                  WorldObject wo = obj as WorldObject;
                  if (wo != null && objRoom.RoomStats.Contained == true)
                  {
                      flag.SetAnimatedState("Enabled", true);
                  }
                  if (wo != null && objRoom.RoomStats.Contained == false)
                  {
                      flag.SetAnimatedState("Enabled", false);
                  }
              });
        }

        public override void Tick()
        {
            CheckRoom(this);
        }

    }

    [Serialized]
    [LocDisplayName("Elixr Mods Flag Wood")]
    [Weight(10)]
    public partial class EMRWFlagItem : WorldObjectItem<EMRWFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The Elixr Mods flag on a beautifuly hand crafted piece of cloth. Display it out front of your house, on your town hall or wherever you like!"); } }

        static EMRWFlagItem()
        {
            WorldObject.AddOccupancy<EMRWFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class EMRWFlagRecipe :
    RecipeFamily
    {
        public EMRWFlagRecipe()
        {
            this.Initialize(Localizer.DoStr("Flag - Elixr Mods - Wood"), typeof(EMRWFlagRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Flag - Elixr Mods - Wood",
                    Localizer.DoStr("Flag - Elixr Mods - Wood"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<EMRWFlagItem>(),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Flag - Elixr Mods - Wood"), typeof(EMRWFlagRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }

}