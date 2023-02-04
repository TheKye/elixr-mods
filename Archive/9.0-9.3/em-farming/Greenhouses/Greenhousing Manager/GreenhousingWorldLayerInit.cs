using Eco.Core.Plugins.Interfaces;
using Eco.Core.Utils;
using Eco.Shared.Utils;
using Eco.Simulation;
using Eco.Simulation.Types;
using Eco.Simulation.WorldLayers;
using Eco.Simulation.WorldLayers.LayerInteractions;
using Eco.Simulation.WorldLayers.Pushers;
using Eco.WorldGenerator;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Eco.EM.Greenhousing
{
    public class GreenhousingWorldLayerInit : IModKitPlugin, IInitializablePlugin
    {
        public string GetStatus() => "Greenhousing Active";

        public void Initialize(TimedTask timer)
        {
            AdjustLayerControl();
        }

        private void AdjustLayerControl()
        {
            var bindings = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
            var syncPushers = (List<IWorldLayerPusher>)NewWorldLayerSync.Obj.GetType().GetProperty("Pushers", bindings).Value(NewWorldLayerSync.Obj);
            var syncInteractions = (List<IWorldLayerInteraction>)NewWorldLayerSync.Obj.GetType().GetProperty("Interactions", bindings).Value(NewWorldLayerSync.Obj);
            syncPushers.RemoveAll(pusher => pusher.GetType() == typeof(PlantSpawner));
            syncPushers.RemoveAll(pusher => pusher.GetType() == typeof(PlantGrower));
           
            NewWorldLayerSync.AddPusher(new EMPlantSpawner());
            foreach (var species in EcoSim.AllSpecies.OfType<PlantSpecies>())
            {
                NewWorldLayerSync.AddPusher(new EMPlantGrower(species));
            }
        }
    }
}
