﻿using Eco.Gameplay.Blocks;
using Eco.Gameplay.Property;
using Eco.World;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eco.EM.Framework.Utils
{
    public static class BlockUtils
    {
        private static readonly Dictionary<Type, Type[]> BlockRotatedVariants = new Dictionary<Type, Type[]>();

        public static Type GetBlockType(string pBlockName)
        {
            pBlockName = pBlockName.ToLower();

            if (pBlockName == "air")
                return typeof(EmptyBlock);

            Type blockType = BlockManager.BlockTypes.FirstOrDefault(t => t.Name.ToLower() == pBlockName + "floorblock");

            if (blockType != null)
                return blockType;

            blockType = BlockManager.BlockTypes.FirstOrDefault(t => t.Name.ToLower() == pBlockName);

            if (blockType != null)
                return blockType;

            return BlockManager.BlockTypes.FirstOrDefault(t => t.Name.ToLower() == pBlockName + "block");
        }

        public static float BlockTypeCount (this RoomStats stats, Type[] types )
        {
            float blockTotal = 0;
            foreach (var pair in stats.WallCompositions)
                if (types.Contains(pair.Key.BlockItemType))
                    blockTotal += pair.Value;

            return blockTotal;
        }

		public static bool HasRotatedVariants(Type blockType, out Type[] variants)
		{
			Type[] possibleVariants = new Type[] { blockType };
			//Cached search
			if (BlockRotatedVariants.TryGetValue(blockType, out variants))
			{
				return variants.Length > 1;
			}
			//DeepSearch
			if (BlockFormManager.Data.BlockForms.Any(form =>
			{
				if (form.BlockTypes.Contains(blockType))
				{
					foreach (Type type in form.BlockTypes) //Probably can just check the length, if there no variants it have only one type = self type
					{
						if (Block.Get<RotatedVariants>(type)?.Variants != null)
						{
							possibleVariants = form.BlockTypes;
							return true;
						}
					}
				}
				return false;
			}
			))
			{
				//Cache results for later
				foreach (Type type in possibleVariants)
				{
					BlockRotatedVariants.Add(type, possibleVariants);
				}
				variants = possibleVariants;
				return true;
			}
			BlockRotatedVariants.Add(blockType, possibleVariants); //Cache results for later
			variants = possibleVariants;
			return false;
		}
	}
}
