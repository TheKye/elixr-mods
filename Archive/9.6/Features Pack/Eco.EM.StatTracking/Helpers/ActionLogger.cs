using Eco.Gameplay.GameActions;
using Eco.Gameplay.Players;
using Eco.Shared.Utils;
using Eco.Simulation.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Eco.Shared.Items.DamagedOrDestroyed;

namespace Eco.EM.StatTracking.Helpers
{
    class ActionLogger
    {
        public static void WriteAction(GameAction action)
        {
            try
            {
                switch (action)
                {
                    case DigOrMine digOrMine:

                        break;
                    case PlowField plowField:

                        break;
                    case TampRoad tampRoad:

                        break;
                    case ConstructOrDeconstruct constructOrDeconstruct:

                        break;
                    case DropOrPickupBlock dropOrPickupBlock:
                        break;
                    case PlaceOrPickUpObject placeOrPickUpObject:

                        break;
                    case DropGarbage dropGarbage:

                        break;
                    case ChopTree chopTree:

                        break;
                    case ChopStump chopStump:
                        break;
                    case CreateTreeDebris createTreeDebris:
                        break;
                    case CleanupTreeDebris cleanupTreeDebris:
                        break;
                    case PlantSeeds plantSeeds:
                        break;
                    case HarvestOrHunt harvestOrHunt:
                        if (ReflectionUtils.DerivesFrom<TreeSpecies>(harvestOrHunt.Species))
                        {
                            break;
                        }
                        if (ReflectionUtils.DerivesFrom<PlantSpecies>(harvestOrHunt.Species))
                        {
                            break;
                        }
                        if (!ReflectionUtils.DerivesFrom<AnimalSpecies>(harvestOrHunt.Species) || harvestOrHunt.DamagedOrDestroyed != DestroyingOrganism)
                            break;
                        break;
                    case InventoryAction inventoryAction:
                        break;
                    case ClaimOrUnclaimProperty orUnclaimProperty:
                        break;
                    case MintCurrency mintCurrency:
                        break;
                    case BarterTrade barterTrade:
                        break;
                    case CurrencyTrade currencyTrade:
                        break;
                    case PropertyTransfer propertyTransfer:
                        break;
                    case TransferMoney transferMoney:
                        break;
                    case ResidencyChanged residencyChanged:
                        break;
                    case StartElection startElection:
                        break;
                    case JoinOrLeaveElection joinOrLeaveElection:
                        break;
                    case WonElection wonElection:
                        break;
                    case LostElection lostElection:
                        break;
                    case Vote vote:
                        break;
                    case GainSpecialty gainSpecialty:
                        break;
                    case SpecialtyLevelUp specialtyLevelUp:
                        break;
                    case CharacterLevelUp characterLevelUp:
                        break;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
