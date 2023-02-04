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
    public partial class MTFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Malta Flag"); } }
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
    [LocDisplayName("Malta Flag")]
    [Ecopedia("Flags", "Country Flags", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Weight(10)]
    public partial class MTFlagItem : WorldObjectItem<MTFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The flag of Malta on a beautifuly hand crafted piece of cloth held up by a well crafted iron stand. Display it out front of your house, on your town hall or wherever you like!"); } }

        static MTFlagItem()
        {
            WorldObject.AddOccupancy<MTFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class MTFlagRecipe :
RecipeFamily
    {
        public MTFlagRecipe()
        {
            this.Initialize(Localizer.DoStr("Flag - Malta"), typeof(MTFlagRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Flag - Malta",
                    Localizer.DoStr("Flag - Malta"),
                    new IngredientElement[]
                    {
                    new IngredientElement(typeof(IronBarItem), 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<MTFlagItem>(),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Flag - Malta"), typeof(MTFlagRecipe));

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
    public partial class MTRWFlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Malta Flag Wood"); } }
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
    [LocDisplayName("Malta Flag Wood")]
    [Weight(10)]
    public partial class MTRWFlagItem : WorldObjectItem<MTRWFlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("The Malta flag on a beautifuly hand crafted piece of cloth. Display it out front of your house, on your town hall or wherever you like!"); } }

        static MTRWFlagItem()
        {
            WorldObject.AddOccupancy<MTRWFlagObject>(new List<BlockOccupancy>(){
            new BlockOccupancy(new Vector3i(0, 0, 0)),
            new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }
    }

    public partial class MTRWFlagRecipe :
    RecipeFamily
    {
        public MTRWFlagRecipe()
        {
            this.Initialize(Localizer.DoStr("Flag - Malta - Wood"), typeof(MTRWFlagRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Flag - Malta",
                    Localizer.DoStr("Flag - Malta - Wood"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<MTRWFlagItem>(),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Flag - Malta - Wood"), typeof(MTRWFlagRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }

}