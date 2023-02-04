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
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Rooms;
    using Eco.Shared.Networking;
    using Eco.Shared.Utils;

    [Serialized]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    public partial class FlagObject : WorldObject
    {
        public override LocString DisplayName { get { return Localizer.DoStr("Test Flag"); } }
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
    [LocDisplayName("Test Flag")]
    [Ecopedia("Flags")]
    [Weight(10)]
    public partial class FlagItem : WorldObjectItem<FlagObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A piece5."); } }
    }

    public partial class FlagRecipe :
RecipeFamily
    {
        public FlagRecipe()
        {
            this.Initialize(Localizer.DoStr("Flag"), typeof(FlagRecipe));
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Flag",
                    Localizer.DoStr("Flag"),
                    new IngredientElement[]
                    {
                    new IngredientElement("Wood", 10),
                    new IngredientElement(typeof(ClothItem), 5)
                    },
                    new CraftingElement[]
                    {
                    new CraftingElement<FlagItem>(2),
                    }
                )
            };

            this.LaborInCalories = CreateLaborInCaloriesValue(30);
            this.CraftMinutes = CreateCraftTimeValue(0.1f);
            this.Initialize(Localizer.DoStr("Flag"), typeof(FlagRecipe));

            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }
    }

}