using System;
using System.Collections.Generic;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Skills;
using Eco.Mods.TechTree;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;

namespace Eco.EM.Furniture
{
    /*public class MailCommands : IChatCommandHandler
    {
        [ChatCommand("Create a new Mail Message", ChatAuthorizationLevel.User)]
        public static void NewMail(User user, string message)
        {
            MailMessageItem newMail = new MailMessageItem(message, user.Name);

            
        }

        [ChatCommand("Create a new Mail Message", ChatAuthorizationLevel.User)]
        public static void NewPackage(User user, string message)
        {

        }

    }*/

    [Serialized, LocDisplayName("House Letterbox")]
    [MaxStackSize(100)]
    public class HouseLetterboxItem : WorldObjectItem<HouseLetterboxObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("To leave your friends messages(WIP) You can leave items in the mail box for people however!"); } }
    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]
    public partial class HouseLetterboxRecipe : RecipeFamily
    {
        private string rName = "House Letterbox";
        private Type skillBase = typeof(CarpentrySkill);
        private Type ingTalent = typeof(CarpentryLavishResourcesTalent);
        private Type[] speedTalents = { typeof(CarpentryParallelSpeedTalent), typeof(CarpentryFocusedSpeedTalent) };

        public HouseLetterboxRecipe()
        {
            var product = new Recipe(
                rName,
                Localizer.DoStr(rName),
                new IngredientElement[]
                {
                    new IngredientElement("Wood", 20, skillBase, ingTalent),
                },
                new CraftingElement<HouseLetterboxItem>(1f)
            );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(100f, skillBase);
            this.CraftMinutes = CreateCraftTimeValue(this.GetType(), 1f, skillBase, speedTalents);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr(rName), this.GetType());
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }


    [Serialized]
    [RequireComponent(typeof(AttachmentComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    public partial class HouseLetterboxObject : WorldObject
    {
        public override LocString DisplayName => Localizer.DoStr("House Letterbox");
        //[Serialized, ThreadSafe] public Queue<KeyValuePair<string, string>> messages = new Queue<KeyValuePair<string, string>>();
        //[Serialized] public bool ContainsMail = false;

        static HouseLetterboxObject()
        {
            AddOccupancy<HouseLetterboxObject>(new List<BlockOccupancy>(){
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            });
        }

        protected override void PostInitialize()
        {
            base.PostInitialize();

            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(4);
            storage.Inventory.AddInvRestriction(new NotCarriedRestriction());
        }
        /* public override InteractResult OnActRight(InteractionContext context)
         {
             //When the owner checks the mailbox
             if (this.NameOfCreator == context.Player.User.Name)
             {
                 if (ContainsMail)
                 {
                     //Dequeue the message and open the letter for the owner
                     KeyValuePair<string, string> toRead = messages.Dequeue();
                     context.Player.OpenInfoPanel($"From: {toRead.Key}", toRead.Value, "mail");

                     //check to see if the message list is empty.
                     if (messages.Count == 0)
                     {
                         ContainsMail = false;
                         SetAnimatedState("Flag", ContainsMail);
                         context.Player.Msg(Localizer.DoStr($"All mail for {context.Player.User.Name} collected!"));
                     }

                     return InteractResult.Success;
                 }

                 return InteractResult.NoOp;
             }

             // When a non-owner attempts to post a message
             if (context.SelectedItem == Item.Get(typeof(MailMessageItem)))
             {
                 if (messages.Count >= 10)
                 {
                     context.Player.Error(Localizer.DoStr("This letterbox appears to be full"));
                     return InteractResult.NoOp;
                 }

                 if (messages.Count == 0)
                 {
                     ContainsMail = true;
                     SetAnimatedState("Flag", ContainsMail);
                 }

                 MailMessageItem newMessage = context.SelectedItem as MailMessageItem;

                 //bundle and queue the message to the letterbox
                 KeyValuePair<string, string> toSend = new KeyValuePair<string, string>(newMessage.Sender, newMessage.Message);
                 messages.Enqueue(toSend);

                 context.Player.Msg(Localizer.DoStr($"Your message for {this.NameOfCreator} has been sent!"));
                 return InteractResult.Success;
             }

             return InteractResult.Failure(Localizer.Do($"Silly {context.Player.User.Name}, you need to create a message using '/newmail' to send a message to {this.NameOfCreator}!"));
         }*/
    }

    /*[Serialized, MaxStackSize(1), LocDisplayName("Mail Message")]
    public class MailMessageItem : Item
    {
        [Serialized] public string Sender { get; set; }
        [Serialized] public string Message { get; set; }

        public MailMessageItem(string m, string s)
        {
            Message = m;
            Sender = s;
        }

        public override void OnUsed(Player player, ItemStack itemStack)
        {
            
        }
    }

    [Serialized, MaxStackSize(1), LocDisplayName("Mail Package")]
    public class MailPackageItem : Item
    {
        [Serialized] public string Sender { get; set; }
        [Serialized] public string Message { get; set; }
        [Serialized] public Item Pack { get; set; }

        public MailPackageItem(Item i, string m, string s)
        {
            Pack = i;
            Message = m;
            Sender = s;
        }
    }*/
}
