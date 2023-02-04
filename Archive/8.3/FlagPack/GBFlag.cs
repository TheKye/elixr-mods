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
    public partial class UKFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("England Flag"); } }
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
    [LocDisplayName("England Flag")]
    [Ecopedia("Flags", "Country Flags", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(10)]
    public partial class UKFlagItem : WorldObjectItem<UKFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The England flag on a beautifuly hand crafted piece of cloth held up by a well crafted iron stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static UKFlagItem()
        {
            WorldObject.AddOccupancy<UKFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class UKFlagRecipe :
RecipeFamily
    {
        public UKFlagRecipe()
        {
            this.Initialize(Localizer.DoStr("Flag - England"), typeof(UKFlagRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Flag - England",
                    Localizer.DoStr("Flag - England"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<UKFlagItem>(),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Flag - England"), typeof(UKFlagRecipe));

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
    public partial class UKRWFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("England Flag Wood"); } }
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
    [LocDisplayName("England Flag Wood")]
    [Weight(10)]
    public partial class UKRWFlagItem : WorldObjectItem<UKRWFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The UK flag on a beautifuly hand crafted piece of cloth. Display it out front of your house, on your town hall or wherever you like!"); } }

        static UKRWFlagItem()
        {
            WorldObject.AddOccupancy<UKRWFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class UKRWFlagRecipe :
    RecipeFamily
    {
        public UKRWFlagRecipe()
        {
            this.Initialize(Localizer.DoStr("Flag - England - Wood"), typeof(UKRWFlagRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Flag - England - Wood",
                    Localizer.DoStr("Flag - England - Wood"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<UKRWFlagItem>(),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Flag - England - Wood"), typeof(UKRWFlagRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }

}