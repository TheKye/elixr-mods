@echo off
echo "This will compile the release Ready modules and output them into bin/9.6/releases. Please ignore the BuildOutput folder. you can safely delete that after running this batch script. If you did not mean to run this then exit now. Files not ready for release have been commented out and will not be included in the release batcher."
pause
::Set Default Paths
set path=%cd%\bin\9.6
set dir=%cd%
set unitydir=%dir%\Built Unity Assets\9.6

::Output Destination
set dest=%dir%\bin\BuildOutput

:: Make our destination directories For Bundles
mkdir "%dest%\EM Artistry\Mods\Elixr Mods\Artistry"
mkdir "%dest%\EM Artistry\Mods\Elixr Mods\Artistry\Assets"
mkdir "%dest%\EM Building\Mods\Elixr Mods\EM Building"
mkdir "%dest%\EM Building\Mods\Elixr Mods\EM Building\Assets"
::mkdir "%dest%\EM Clothing\Mods\Elixr Mods\EM Clothing"
::mkdir "%dest%\EM Clothing\Mods\Elixr Mods\EM Clothing\Assets"
::mkdir "%dest%\EM Energy\Mods\Elixr Mods\EM Energy"
::mkdir "%dest%\EM Energy\Mods\Elixr Mods\EM Energy\Assets"
mkdir "%dest%\EM Flags\Mods\Elixr Mods\EM Flags"
mkdir "%dest%\EM Flags\Mods\Elixr Mods\EM Flags\Assets"
mkdir "%dest%\EM Food\Mods\Elixr Mods\EM Food"
mkdir "%dest%\EM Food\Mods\Elixr Mods\EM Food\Assets"
mkdir "%dest%\EM Games\Mods\Elixr Mods\EM Games"
mkdir "%dest%\EM Games\Mods\Elixr Mods\EM Games\Assets"
mkdir "%dest%\EM Housing\Mods\Elixr Mods\EM Housing"
mkdir "%dest%\EM Housing\Mods\Elixr Mods\EM Housing\Assets"
mkdir "%dest%\EM Machines\Mods\Elixr Mods\EM Machines"
mkdir "%dest%\EM Machines\Mods\Elixr Mods\EM Machines\Assets"
::mkdir "%dest%\EM SciFi\Mods\Elixr Mods\EM SciFi"
::mkdir "%dest%\EM SciFi\Mods\Elixr Mods\EM SciFi\Assets"
mkdir "%dest%\EM Storage\Mods\Elixr Mods\EM Storage"
mkdir "%dest%\EM Storage\Mods\Elixr Mods\EM Storage\Assets"
mkdir "%dest%\EM Features Pack\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\EM Features Pack\Mods\Elixr Mods\Features Pack\Assets"
mkdir "%dest%\Mods\Translations"

:: Set Bundle Outputs
set embuilding=%dest%\EM Building\Mods\Elixr Mods\EM Building
::set emclothing=%dest%\EM Clothing\Mods\Elixr Mods\EM Clothing
::set emenergy=%dest%\EM Energy\Mods\Elixr Mods\EM Energy
set emflags=%dest%\EM Flags\Mods\Elixr Mods\EM Flags
set emfood=%dest%\EM Food\Mods\Elixr Mods\EM Food
set emgames=%dest%\EM Games\Mods\Elixr Mods\EM Games
set emhousing=%dest%\EM Housing\Mods\Elixr Mods\EM Housing
set emmachines=%dest%\EM Machines\Mods\Elixr Mods\EM Machines
::set emscifi=%dest%\EM SciFi\Mods\Elixr Mods\EM SciFi
set emstorage=%dest%\EM Storage\Mods\Elixr Mods\EM Storage
set emfeatures=%dest%\EM Features Pack\Mods\Elixr Mods\Features Pack

::set bundle unity outputs
set embuildingassets=%embuilding%\Assets
::set emclothingassets=%emclothing%\Assets
::set emenergyassets=%emenergy%\Assets
set emflagsassets=%emflags%\Assets
set emfoodassets=%emfood%\Assets
set emgamesassets=%emgames%\Assets
set emhousingassets=%emhousing%\Assets
set emmachinesassets=%emmachines%\Assets
::set emscifiassets=%emscifi%\Assets
set emstorageassets=%emstorage%\Assets
set emfeaturesassets=%emfeatures%\Assets

::Set original Unity Asset Bundles Locations
set unityembuildingassets=%unitydir%\EM Building\Assets
::set unityemclothingassets=%unitydir%\EM Clothing\Assets
::set unityemenergyassets=%unitydir%\EM Energy\Assets
set unityemflagsassets=%unitydir%\EM Flags\Assets
set unityemfoodassets=%unitydir%\EM Food\Assets
set unityemgamesassets=%unitydir%\EM Games\Assets
set unityemhousingassets=%unitydir%\EM Housing\Assets
set unityemmachinesassets=%unitydir%\EM Machines\Assets
::set unityemscifiassets=%unitydir%\EM SciFi\Assets
set unityemstorageassets=%unitydir%\EM Storage\Assets
set unityemfeaturesassets=%unitydir%\Features Pack\Assets

:: Core File Locations And Unity File Locations
:: Framework
set framework=%dir%\EM Framework\Eco.EM.Framework.dll

:: Artistry
set artistry=%path%\Artistry\net7.0\Eco.EM.Artistry.dll
set artistryAssets=%unitydir%\Artistry\Assets\EM-Artistry.unity3d

:: Features Pack
set admin=%path%\Features Pack\net7.0\Eco.EM.Admin.dll
set commands=%path%\Features Pack\net7.0\Eco.EM.Commands.dll
set daily=%path%\Features Pack\net7.0\Eco.EM.Daily.dll
set dailyAssets=%unitydir%\Features Pack\Assets\EM-Daily.unity3d
set home=%path%\Features Pack\net7.0\Eco.EM.Homes.dll
set informatics=%path%\Features Pack\net7.0\Eco.EM.Informatics.dll
set motd=%path%\Features Pack\net7.0\Eco.EM.MOTD.dll
set tp=%path%\Features Pack\net7.0\Eco.EM.TP.dll
set warp=%path%\Features Pack\net7.0\Eco.EM.Warp.dll
set warpAssets=%unitydir%\Features Pack\Assets\EM-Warps.unity3d
set autodoor=%path%\Features Pack\net7.0\Eco.EM.AutomaticDoors.dll
set autodoorAssets=%unitydir%\Features Pack\Assets\EM-AutoDoors.unity3d

:: EM Building
set arches=%path%\EM Building\net7.0\Eco.EM.Building.Arches.dll
set archesAssets=%unitydir%\EM Building\Assets\EM-Arches.unity3d
set bricks=%path%\EM Building\net7.0\Eco.EM.Building.Bricks.dll
set bricksAssets=%unitydir%\EM Building\Assets\EM-Bricks.unity3d
set concrete=%path%\EM Building\net7.0\Eco.EM.Building.Concrete.dll
set concreteAssets=%unitydir%\EM Building\Assets\EM-Concrete.unity3d
set greenhouse=%path%\EM Building\net7.0\Eco.EM.Building.Greenhousing.dll
set greenhouseAssets=%unitydir%\EM Building\Assets\EM-Greenhousing.unity3d
set roadworking=%path%\EM Building\net7.0\Eco.EM.Building.Roadworking.dll
set roadworkingAssets=%unitydir%\EM Building\Assets\EM-Roadworking.unity3d
::set shelving=%path%\EM Building\net7.0\Eco.EM.Building.Shelving.dll
::set shelvingAssets=%unitydir%\EM Building\Assets\EM-Shelving.unity3d
::set tools=%path%\EM Building\net7.0\Eco.EM.Building.Tools.dll
::set toolsAssets=%unitydir%\EM Building\Assets\EM-Tools.unity3d
set windows=%path%\EM Building\net7.0\Eco.EM.Building.Windows.dll
set windowsAssets=%unitydir%\EM Building\Assets\EM-Windows.unity3d
set brickarches=%path%\EM Building\net7.0\Eco.EM.Bricks.Arches.dll
set brickarchesAssets=%unitydir%\EM Building\Assets\EM-ColoredBrickArches.unity3d
set blocks=%path%\EM Building\net7.0\Eco.EM.Building.Blocks.dll
set blocksAssets=%unitydir%\EM Building\Assets\EM-Blocks

:: EM Clothing
::set clothes=%path%\\EM Clothing\net7.0\Eco.EM.Clothes.dll
::set clothesAssets=%unitydir%\EM Clothing\Assets\EM-Clothes.unity3d

:: EM Energy
::set electronics=%path%\EM Energy\net7.0\Eco.EM.Energy.Electronics.dll
::set electronicsAssets=%unitydir%\EM Energy\Assets\EM-Electronics.unity3d
::set fuel=%path%\EM Energy\net7.0\Eco.EM.Energy.Fuel.dll
::set fuelAssets=%unitydir%\EM Energy\Assets\EM-Fuel.unity3d
::set greenenergy=%path%\EM Energy\net7.0\Eco.EM.Energy.GreenEnergy.dll
::set greenenergyAssets=%unitydir%\EM Energy\Assets\EM-GreenEnergy.unity3d
::set nuclearenergy=%path%\EM Energy\net7.0\Eco.EM.Energy.NuclearEnergy.dll
::set nuclearenergyAssets=%unitydir%\EM Energy\Assets\EM-NuclearEnergy.unity3d
::set sensors=%path%\EM Energy\net7.0\Eco.EM.Energy.Sensors.dll
::set sensorsAssets=%unitydir%\EM Energy\Assets\EM-Sensors.unity3d

:: EM Food
::set farming=%path%\EM Food\net7.0\Eco.EM.Food.Farming.dll
::set farmingAssets=%unitydir%\EM Food\Assets\EM-Farming.unity3d
::set foodsmoking=%path%\EM Food\net7.0\Eco.EM.Food.FoodSmoking.dll
::set foodsmokingAssets=%unitydir%\EM Food\Assets\EM-Foodsmoking.unity3d
::set hunting=%path%\EM Food\net7.0\Eco.EM.Food.Hunting.dll
::set huntingAssets=%unitydir%\EM Food\Assets\EM-Hunting.unity3d
::set zymology=%path%\EM Food\net7.0\Eco.EM.Food.Zymology.dll
::set zymologyAssets=%unitydir%\EM Food\Assets\EM-Zymology.unity3d
::set cafe=%path%\EM Food\net7.0\Eco.EM.Food.Cafe.dll
::set cafeAssets=%unitydir%\EM Food\Assets\EM-Cafe.unity3d
::set cuisine=%path%\EM Food\net7.0\Eco.EM.Food.Cuisine.dll
::set cuisineAssets=%unitydir%\EM Food\Assets\EM-Cuisine.unity3d

:: EM Flags
set flags=%path%\Flags\net7.0\Eco.EM.Flags.dll
set flagsAssets=%unitydir%\EM Flags\Assets\EM-Flags.unity3d

:: EM Games
set boardgames=%path%\EM Games\net7.0\Eco.EM.Games.BoardGames.dll
set boardgamesAssets=%unitydir%\EM Games\Assets\EM-BoardGames.unity3d
set boardtools=%path%\EM Games\net7.0\Eco.EM.Games.BoardTools.dll
set boardtoolsAssets=%unitydir%\EM Games\Assets\EM-BoardTools.unity3d

:: EM Housing
set furniture=%path%\EM Housing\net7.0\Eco.EM.Housing.Furniture.dll
set furnitureAssets=%unitydir%\EM Housing\Assets\EM-Furniture.unity3d
set doors=%path%\EM Housing\net7.0\Eco.EM.Housing.Doors.dll
set doorsAssets=%unitydir%\EM Housing\Assets\EM-Doors.unity3d
::set paintings=%path%\EM Housing\net7.0\Eco.EM.Housing.Paintings.dll
::set paintingsAssets=%unitydir%\EM Housing\Assets\EM-Paintings.unity3d

:: EM Machines
::set conveyors=%path%\EM Machines\net7.0\Eco.EM.Machines.Conveyors.dll
::set conveyorsAssets=%unitydir%\EM Machines\Assets\EM-Conveyors.unity3d
::set automation=%path%\EM Machines\net7.0\Eco.EM.Machines.Automation.dll
::set automationAssets=%unitydir%\EM Machines\Assets\EM-Automation.unity3d
::set production=%path%\EM Machines\net7.0\Eco.EM.Machines.Production.dll
::set productionAssets=%unitydir%\EM Machines\Assets\EM-Production.unity3d
set trucking=%path%\EM Machines\net7.0\Eco.EM.Machines.Trucking.dll
set truckingAssets=%unitydir%\EM Machines\Assets\EM-Trucking.unity3d
set vehicles=%path%\EM Machines\net7.0\Eco.EM.Machines.Vehicles.dll
set vehiclesAssets=%unitydir%\EM Machines\Assets\EM-Vehicles.unity3d

:: EM Sci Fi
::set scifi=%path%\EM SciFi\net7.0\Eco.EM.SciFi.dll
::set scifiAssets=%unitydir%\EM SciFi\Assets\EM-SciFi.unity3d

:: EM Storage
set shipping=%path%\EM Storage\net7.0\Eco.EM.Storage.Shipping.dll
set shippingAssets=%unitydir%\EM Storage\Assets\EM-Shipping.unity3d
set stockpiling=%path%\EM Storage\net7.0\Eco.EM.Storage.Stockpiling.dll
set stockpilingAssets=%unitydir%\EM Storage\Assets\EM-Stockpiling.unity3d
::set warehousing=%path%\EM Storage\net7.0\Eco.EM.Storage.Warehousing.dll
::set warehousingAssets=%unitydir%\EM Storage\Assets\EM-Warehousing.unity3d

:: Changelog
set changelog=%dir%\ChangeLog.txt

::Make the Output directories For Individual Modules
::Features Pack | Make Directories
mkdir "%dest%\Admin\Mods\Elixr Mods\Features Pack"
::mkdir "%dest%\APS\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\Commands\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\Daily\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\Daily\Mods\Elixr Mods\Features Pack\Assets"
mkdir "%dest%\Home\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\Informatics\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\MOTD\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\TP\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\Warp\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\Warp\Mods\Elixr Mods\Features Pack\Assets"
mkdir "%dest%\AutoDoors\Mods\Elixr Mods\Features Pack"
mkdir "%dest%\AutoDoors\Mods\Elixr Mods\Features Pack\Assets"

:: Define Destination
set admindest=%dest%\Admin\Mods\Elixr Mods\Features Pack
::set apsdest=%dest%\APS\Mods\Elixr Mods\Features Pack
set commandsdest=%dest%\Commands\Mods\Elixr Mods\Features Pack
set dailydest=%dest%\Daily\Mods\Elixr Mods\Features Pack
set dailyassetdest=%dest%\Daily\Mods\Elixr Mods\Features Pack\Assets
set homedest=%dest%\Home\Mods\Elixr Mods\Features Pack
set infodest=%dest%\Informatics\Mods\Elixr Mods\Features Pack
set motddest=%dest%\MOTD\Mods\Elixr Mods\Features Pack
set tpdest=%dest%\TP\Mods\Elixr Mods\Features Pack
set warpdest=%dest%\Warp\Mods\Elixr Mods\Features Pack
set warpassetdest=%dest%\Warp\Mods\Elixr Mods\Features Pack\Assets
set autodoordest=%dest%\AutoDoors\Mods\Elixr Mods\Features Pack
set autodoorassetdest=%dest%\AutoDoors\Mods\Elixr Mods\Features Pack\Assets

:: Artistry | Make Directories
mkdir "%dest%\EM Artistry\Mods\Elixr Mods\Artistry"
mkdir "%dest%\EM Artistry\Mods\Elixr Mods\Artistry\Assets"

:: Define Destination
set artdest=%dest%\EM Artistry\Mods\Elixr Mods\Artistry
set artassetdest=%dest%\EM Artistry\Mods\Elixr Mods\Artistry\Assets

:: Framework | Make Directories
mkdir "%dest%\Framework\Mods\Elixr Mods\"

:: Define Destination
set frameworkdest=%dest%\Framework\Mods\Elixr Mods\

:: EM Building | Make Directories
mkdir "%dest%\Arches\Mods\Elixr Mods\EM Building"
mkdir "%dest%\Arches\Mods\Elixr Mods\EM Building\Assets"
mkdir "%dest%\Bricks\Mods\Elixr Mods\EM Building"
mkdir "%dest%\Bricks\Mods\Elixr Mods\EM Building\Assets"
mkdir "%dest%\Concrete\Mods\Elixr Mods\EM Building"
mkdir "%dest%\Concrete\Mods\Elixr Mods\EM Building\Assets"
mkdir "%dest%\Greenhousing\Mods\Elixr Mods\EM Building"
mkdir "%dest%\Greenhousing\Mods\Elixr Mods\EM Building\Assets"
mkdir "%dest%\Roadworking\Mods\Elixr Mods\EM Building"
mkdir "%dest%\Roadworking\Mods\Elixr Mods\EM Building\Assets"
::mkdir "%dest%\Shelving\Mods\Elixr Mods\EM Building"
::mkdir "%dest%\Shelving\Mods\Elixr Mods\EM Building\Assets"
::mkdir "%dest%\Tools\Mods\Elixr Mods\EM Building"
::mkdir "%dest%\Tools\Mods\Elixr Mods\EM Building\Assets"
mkdir "%dest%\Windows\Mods\Elixr Mods\EM Building"
mkdir "%dest%\Windows\Mods\Elixr Mods\EM Building\Assets"
mkdir "%dest%\BrickArches\Mods\Elixr Mods\EM Building"
mkdir "%dest%\BrickArches\Mods\Elixr Mods\EM Building\Assets"
mkdir "%dest%\Blocks\Mods\Elixr Mods\EM Building"
mkdir "%dest%\Blocks\Mods\Elixr Mods\EM Building\Assets"

:: Define Destination
set archesdest=%dest%\Arches\Mods\Elixr Mods\EM Building
set archesassetdest=%dest%\Arches\Mods\Elixr Mods\EM Building\Assets
set bricksdest=%dest%\Bricks\Mods\Elixr Mods\EM Building
set bricksassetdest=%dest%\Bricks\Mods\Elixr Mods\EM Building\Assets
set concretedest=%dest%\Concrete\Mods\Elixr Mods\EM Building
set concreteassetdest=%dest%\Concrete\Mods\Elixr Mods\EM Building\Assets
set greenhousingdest=%dest%\Greenhousing\Mods\Elixr Mods\EM Building
set greenhousingassetdest=%dest%\Greenhousing\Mods\Elixr Mods\EM Building\Assets
set roadworkingdest=%dest%\Roadworking\Mods\Elixr Mods\EM Building
set roadworkingassetdest=%dest%\Roadworking\Mods\Elixr Mods\EM Building\Assets
::set shelvingdest=%dest%\Shelving\Mods\Elixr Mods\EM Building
::set shelvingassetdest=%dest%\Shelving\Mods\Elixr Mods\EM Building\Assets
::set toolsdest=%dest%\Tools\Mods\Elixr Mods\EM Building
::set toolsassetdest=%dest%\Tools\Mods\Elixr Mods\EM Building\Assets
set windowsdest=%dest%\Windows\Mods\Elixr Mods\EM Building
set windowsassetdest=%dest%\Windows\Mods\Elixr Mods\EM Building\Assets
set brickarchdest=%dest%\BrickArches\Mods\Elixr Mods\EM Building
set brickarchassetdest=%dest%\BrickArches\Mods\Elixr Mods\EM Building\Assets
set blocksdest=%dest%\Blocks\Mods\Elixr Mods\EM Building
set blocksassetdest=%dest%\Blocks\Mods\Elixr Mods\EM Building\Assets\EM-Blocks

:: EM Clothing | Make Directories
::mkdir "%dest%\Clothes\Mods\Elixr Mods\EM Clothing"
::mkdir "%dest%\Clothes\Mods\Elixr Mods\EM Clothing\Assets"

:: Define Destination
::set clothesdest=%dest%\Clothes\Mods\Elixr Mods\EM Clothing
::set clothesassetdest=%dest%\Clothes\Mods\Elixr Mods\EM Clothing\Assets

:: EM Energy | Make Directories
::mkdir "%dest%\Electronics\Mods\Elixr Mods\EM Energy"
::mkdir "%dest%\Electronics\Mods\Elixr Mods\EM Energy\Assets"
::mkdir "%dest%\Fuel\Mods\Elixr Mods\EM Energy"
::mkdir "%dest%\Fuel\Mods\Elixr Mods\EM Energy\Assets"
::mkdir "%dest%\GreenEnergy\Mods\Elixr Mods\EM Energy"
::mkdir "%dest%\GreenEnergy\Mods\Elixr Mods\EM Energy\Assets"
::mkdir "%dest%\NuclearEnergy\Mods\Elixr Mods\EM Energy"
::mkdir "%dest%\NuclearEnergy\Mods\Elixr Mods\EM Energy\Assets"
::mkdir "%dest%\Sensors\Mods\Elixr Mods\EM Energy"
::mkdir "%dest%\Sensors\Mods\Elixr Mods\EM Energy\Assets"

:: Define Destination
::set electronicsdest=%dest%\Electronics\Mods\Elixr Mods\EM Energy
::set electronicsassetdest=%dest%\Electronics\Mods\Elixr Mods\EM Energy\Assets
::set fueldest=%dest%\Fuel\Mods\Elixr Mods\EM Energy
::set fuelassetdest=%dest%\Fuel\Mods\Elixr Mods\EM Energy\Assets
::set greenenergydest=%dest%\GreenEnergy\Mods\Elixr Mods\EM Energy
::set greenenergyassetdest=%dest%\GreenEnergy\Mods\Elixr Mods\EM Energy\Assets
::set nuclearenergydest=%dest%\NuclearEnergy\Mods\Elixr Mods\EM Energy
::set nuclearenergyassetdest=%dest%\NuclearEnergy\Mods\Elixr Mods\EM Energy\Assets
::set sensorsdest=%dest%\Sensors\Mods\Elixr Mods\EM Energy
::set sensorsassetdest=%dest%\Sensors\Mods\Elixr Mods\EM Energy\Assets

:: EM Flags | Make Directories
mkdir "%dest%\Flags\Mods\Elixr Mods\EM Flags"
mkdir "%dest%\Flags\Mods\Elixr Mods\EM Flags\Assets"

:: Define Destination
set flagsdest=%dest%\Flags\Mods\Elixr Mods\EM Flags
set flagsassetdest=%dest%\Flags\Mods\Elixr Mods\EM Flags\Assets

:: EM Food | Make Directories
::mkdir "%dest%\Farming\Mods\Elixr Mods\EM Food"
::mkdir "%dest%\Farming\Mods\Elixr Mods\EM Food\Assets"
::mkdir "%dest%\FoodSmoking\Mods\Elixr Mods\EM Food"
::mkdir "%dest%\FoodSmoking\Mods\Elixr Mods\EM Food\Assets"
::mkdir "%dest%\Hunting\Mods\Elixr Mods\EM Food"
::mkdir "%dest%\Hunting\Mods\Elixr Mods\EM Food\Assets"
::mkdir "%dest%\Zymology\Mods\Elixr Mods\EM Food"
::mkdir "%dest%\Zymology\Mods\Elixr Mods\EM Food\Assets"

:: Define Destination
::set farmingdest=%dest%\Farming\Mods\Elixr Mods\EM Food
::set farmingassetdest=%dest%\Farming\Mods\Elixr Mods\EM Food\Assets
::set foodsmokingdest=%dest%\FoodSmoking\Mods\Elixr Mods\EM Food
::set foodsmokingassetdest=%dest%\FoodSmoking\Mods\Elixr Mods\EM Food\Assets
::set huntingdest=%dest%\Hunting\Mods\Elixr Mods\EM Food
::set huntingassetdest=%dest%\Hunting\Mods\Elixr Mods\EM Food\Assets
::set zymologydest=%dest%\Zymology\Mods\Elixr Mods\EM Food
::set zymologyassetdest=%dest%\Zymology\Mods\Elixr Mods\EM Food\Assets

:: EM Games | Make Directories
mkdir "%dest%\BoardGames\Mods\Elixr Mods\EM Games"
mkdir "%dest%\BoardGames\Mods\Elixr Mods\EM Games\Assets"
mkdir "%dest%\BoardTools\Mods\Elixr Mods\EM Games"
mkdir "%dest%\BoardTools\Mods\Elixr Mods\EM Games\Assets"

:: Define Destination
set boardgamesdest=%dest%\BoardGames\Mods\Elixr Mods\EM Games
set boardgamesassetdest=%dest%\BoardGames\Mods\Elixr Mods\EM Games\Assets
set boardtoolsdest=%dest%\BoardTools\Mods\Elixr Mods\EM Games
set boardtoolsassetdest=%dest%\BoardTools\Mods\Elixr Mods\EM Games\Assets

:: EM Housing | Make Directories
mkdir "%dest%\Doors\Mods\Elixr Mods\EM Housing"
mkdir "%dest%\Doors\Mods\Elixr Mods\EM Housing\Assets"
mkdir "%dest%\Furniture\Mods\Elixr Mods\EM Housing"
mkdir "%dest%\Furniture\Mods\Elixr Mods\EM Housing\Assets"

:: Define Destination
set doorsdest=%dest%\Doors\Mods\Elixr Mods\EM Housing
set doorsassetdest=%dest%\Doors\Mods\Elixr Mods\EM Housing\Assets
set furnituredest=%dest%\Furniture\Mods\Elixr Mods\EM Housing
set furnitureassetdest=%dest%\Furniture\Mods\Elixr Mods\EM Housing\Assets

:: EM Machines | Make Directories
::mkdir "%dest%\Automation\Mods\Elixr Mods\EM Machines"
::mkdir "%dest%\Automation\Mods\Elixr Mods\EM Machines\Assets"
::mkdir "%dest%\Conveyors\Mods\Elixr Mods\EM Machines"
::mkdir "%dest%\Conveyors\Mods\Elixr Mods\EM Machines\Assets"
::mkdir "%dest%\Production\Mods\Elixr Mods\EM Machines"
::mkdir "%dest%\Production\Mods\Elixr Mods\EM Machines\Assets"
mkdir "%dest%\Trucking\Mods\Elixr Mods\EM Machines"
mkdir "%dest%\Trucking\Mods\Elixr Mods\EM Machines\Assets"
mkdir "%dest%\Vehicles\Mods\Elixr Mods\EM Machines"
mkdir "%dest%\Vehicles\Mods\Elixr Mods\EM Machines\Assets"

:: Define Destination
::set automationdest=%dest%\Automation\Mods\Elixr Mods\EM Machines
::set automationassetdest=%dest%\Automation\Mods\Elixr Mods\EM Machines\Assets
::set conveyorsdest=%dest%\Conveyors\Mods\Elixr Mods\EM Machines
::set conveyorsassetdest=%dest%\Conveyors\Mods\Elixr Mods\EM Machines\Assets
::set productiondest=%dest%\Production\Mods\Elixr Mods\EM Machines
::set productionassetdest=%dest%\Production\Mods\Elixr Mods\EM Machines\Assets
set truckingdest=%dest%\Trucking\Mods\Elixr Mods\EM Machines
set truckingassetdest=%dest%\Trucking\Mods\Elixr Mods\EM Machines\Assets
set vehicledest=%dest%\Vehicles\Mods\Elixr Mods\EM Machines
set vehicleassetdest=%dest%\Vehicles\Mods\Elixr Mods\EM Machines\Assets

:: EM SciFi | Make Directories
::mkdir "%dest%\SciFi\Mods\Elixr Mods\EM SciFi"
::mkdir "%dest%\SciFi\Mods\Elixr Mods\EM SciFi\Assets"

:: Define Destination
::set scifidest=%dest%\SciFi\Mods\Elixr Mods\EM SciFi
::set scifiassetdest=%dest%\SciFi\Mods\Elixr Mods\EM SciFi\Assets

:: EM Storage | Make Directories
mkdir "%dest%\Shipping\Mods\Elixr Mods\EM Shipping"
mkdir "%dest%\Shipping\Mods\Elixr Mods\EM Shipping\Assets"
mkdir "%dest%\Stockpiling\Mods\Elixr Mods\EM Shipping"
mkdir "%dest%\Stockpiling\Mods\Elixr Mods\EM Shipping\Assets"
::mkdir "%dest%\Warehousing\Mods\Elixr Mods\EM Shipping"
::mkdir "%dest%\Warehousing\Mods\Elixr Mods\EM Shipping\Assets"

:: Define Destination
set shippingdest=%dest%\Shipping\Mods\Elixr Mods\EM Shipping
set shippingassetdest=%dest%\Shipping\Mods\Elixr Mods\EM Shipping\Assets
set stockpilingdest=%dest%\Stockpiling\Mods\Elixr Mods\EM Shipping
set stockpilingassetdest=%dest%\Stockpiling\Mods\Elixr Mods\EM Shipping\Assets
::set warehousingdest=%dest%\Warehousing\Mods\Elixr Mods\EM Shipping
::set warehousingassetdest=%dest%\Warehousing\Mods\Elixr Mods\EM Shipping\Assets

:: Build Individual Bundles 
echo Building Bundles
@echo on
:: Framework
copy "%framework%" "%frameworkdest%" /y

:: Artistry
copy "%artistry%" "%artdest%" /y
copy "%artistryAssets%" "%artassetdest%" /y

:: Building
copy "%arches%" "%archesdest%" /y
copy "%archesAssets%" "%archesassetdest%" /y
copy "%bricks%" "%bricksdest%" /y
copy "%bricksAssets%" "%bricksassetdest%" /y
copy "%concrete%" "%concretedest%" /y
copy "%concreteAssets%" "%concreteassetdest%" /y
copy "%greenhouse%" "%greenhousingdest%" /y
copy "%greenhouseAssets%" "%greenhousingassetdest%" /y
copy "%roadworking%" "%roadworkingdest%" /y
copy "%roadworkingAssets%" "%roadworkingassetdest%" /y
::copy "%shelving%" "%shelvingdest%" /y
::copy "%shelvingAssets%" "%shelvingassetdest%" /y
::copy "%tools%" "%toolsdest%" /y
::copy "%toolsAssets%" "%toolsassetdest%" /y
copy "%windows%" "%windowsdest%" /y
copy "%windowsAssets%" "%windowsassetdest%" /y
copy "%brickarches%" "%brickarchdest%" /y
copy "%brickarchesAssets%" "%brickarchassetdest%" /y
copy "%blocks%" "%blocksdest%" /y
"C:\Windows\System32\robocopy.exe" /s "%blocksAssets%" "%blocksassetdest%"

:: Clothing
::copy "%clothes%" "%clothesdest%" /y
::copy "%clothesAssets%" "%clothesassetdest%" /y

:: Energy
::copy "%electronics%" "%electronicsdest%" /y
::copy "%electronicsAssets%" "%electronicsassetdest%" /y
::copy "%fuel%" "%fueldest%" /y
::copy "%fuelAssets%" "%fuelassetdest%" /y
::copy "%greenenergy%" "%greenenergydest%" /y
::copy "%greenenergyAssets%" "%greenenergyassetdest%" /y
::copy "%nuclearenergy%" "%nuclearenergydest%" /y
::copy "%nuclearenergyAssets%" "%nuclearenergyassetdest%" /y
::copy "%sensors%" "%sensorsdest%" /y
::copy "%sensorsAssets%" "%sensorsassetdest%" /y

:: Flags
copy "%flags%" "%flagsdest%" /y
copy "%flagsAssets%" "%flagsassetdest%" /y

:: Food
::copy "%farming%" "%farmingdest%" /y
::copy "%farmingAssets%" "%farmingassetdest%" /y
::copy "%foodsmoking%" "%foodsmokingdest%" /y
::copy "%foodsmokingAssets%" "%foodsmokingassetdest%" /y
::copy "%hunting%" "%huntingdest%" /y
::copy "%huntingAssets%" "%huntingassetdest%" /y
::copy "%zymology%" "%zymologydest%" /y
::copy "%zymologyAssets%" "%zymologyassetdest%" /y

:: Games
copy "%boardgames%" "%boardgamesdest%" /y
copy "%boardgamesAssets%" "%boardgamesassetdest%" /y
copy "%boardtools%" "%boardtoolsdest%" /y
copy "%boardtoolsAssets%" "%boardtoolsassetdest%" /y

:: Housing
copy "%doors%" "%doorsdest%" /y
copy "%doorsAssets%" "%doorsassetdest%" /y
copy "%furniture%" "%furnituredest%" /y
copy "%furnitureAssets%" "%furnitureassetdest%" /y

:: Machines
::copy "%automation%" "%automationdest%" /y
::copy "%automationAssets%" "%automationassetdest%" /y
::copy "%conveyors%" "%conveyorsdest%" /y
::copy "%conveyorsAssets%" "%conveyorsassetdest%" /y
::copy "%production%" "%productiondest%" /y
::copy "%productionAssets%" "%productionassetdest%" /y
copy "%trucking%" "%truckingdest%" /y
copy "%truckingAssets%" "%truckingassetdest%" /y
copy "%vehicles%" "%vehicledest%" /y
copy "%vehiclesAssets%" "%vehicleassetdest%" /y

:: SciFi
::copy "%scifi%" "%scifidest%" /y
::copy "%scifiAssets%" "%scifiassetdest%" /y

:: Storage
copy "%shipping%" "%shippingdest%" /y
copy "%shippingAssets%" "%shippingassetdest%" /y
copy "%stockpiling%" "%stockpilingdest%" /y
copy "%stockpilingAssets%" "%stockpilingassetdest%" /y
::copy "%warehousing%" "%warehousingdest%" /y
::copy "%warehousingAssets%" "%warehousingassetdest%" /y

:: Features
copy "%admin%" "%admindest%" /y
copy "%commands%" "%commandsdest%" /y
copy "%daily%" "%dailydest%" /y
copy "%dailyAssets%" "%dailyassetdest%" /y
copy "%home%" "%homedest%" /y
copy "%informatics%" "%infodest%" /y
copy "%motd%" "%motddest%" /y
copy "%tp%" "%tpdest%" /y
copy "%warp%" "%warpdest%" /y
copy "%warpAssets%" "%warpassetdest%" /y
copy "%autodoor%" "%autodoordest%" /y
copy "%autodoorAssets%" "%autodoorassetdest%" /y

::Build Bundles

:: Building
copy "%arches%" "%embuilding%" /y
copy "%archesAssets%" "%embuildingassets%" /y
copy "%bricks%" "%embuilding%" /y
copy "%bricksAssets%" "%embuildingassets%" /y
copy "%concrete%" "%embuilding%" /y
copy "%concreteAssets%" "%embuildingassets%" /y
copy "%greenhouse%" "%embuilding%" /y
copy "%greenhouseAssets%" "%embuildingassets%" /y
copy "%roadworking%" "%embuilding%" /y
copy "%roadworkingAssets%" "%embuildingassets%" /y
::copy "%shelving%" "%embuilding%" /y
::copy "%shelvingAssets%" "%embuildingassets%" /y
::copy "%tools%" "%embuilding%" /y
::copy "%toolsAssets%" "%embuildingassets%" /y
copy "%windows%" "%embuilding%" /y
copy "%windowsAssets%" "%embuildingassets%" /y
copy "%brickarches%" "%embuilding%" /y
copy "%brickarchesAssets%" "%embuildingassets%" /y
copy "%blocks%" "%embuilding%" /y
"C:\Windows\System32\robocopy.exe" /s "%blocksAssets%" "%embuildingassets%/EM-Blocks"

:: Clothing
::copy "%clothes%" "%emclothing%" /y
::copy "%clothesAssets%" "%emclothingassets%" /y

:: Energy
::copy "%electronics%" "%emenergy%" /y
::copy "%electronicsAssets%" "%emenergyassets%" /y
::copy "%fuel%" "%emenergy%" /y
::copy "%fuelAssets%" "%emenergyassets%" /y
::copy "%greenenergy%" "%emenergy%" /y
::copy "%greenenergyAssets%" "%emenergyassets%" /y
::copy "%nuclearenergy%" "%emenergy%" /y
::copy "%nuclearenergyAssets%" "%emenergyassets%" /y
::copy "%sensors%" "%emenergy%" /y
::copy "%sensorsAssets%" "%emenergyassets%" /y

:: Flags
copy "%flags%" "%emflags%" /y
copy "%flagsAssets%" "%emflagsassets%" /y

:: Food
::copy "%farming%" "%emfood%" /y
::copy "%farmingAssets%" "%emfoodassets%" /y
::copy "%foodsmoking%" "%emfood%" /y
::copy "%foodsmokingAssets%" "%emfoodassets%" /y
::copy "%hunting%" "%emfood%" /y
::copy "%huntingAssets%" "%emfoodassets%" /y
::copy "%zymology%" "%emfood%" /y
::copy "%zymologyAssets%" "%emfoodassets%" /y

:: Games
copy "%boardgames%" "%emgames%" /y
copy "%boardgamesAssets%" "%emgamesassets%" /y
copy "%boardtools%" "%emgames%" /y
copy "%boardtoolsAssets%" "%emgamesassets%" /y

:: Housing
copy "%doors%" "%emhousing%" /y
copy "%doorsAssets%" "%emhousingassets%" /y
copy "%furniture%" "%emhousing%" /y
copy "%furnitureAssets%" "%emhousingassets%" /y

:: Machines
::copy "%automation%" "%emmachines%" /y
::copy "%automationAssets%" "%emmachinesassets%" /y
::copy "%conveyors%" "%emmachines%" /y
::copy "%conveyorsAssets%" "%emmachinesassets%" /y
::copy "%production%" "%emmachines%" /y
::copy "%productionAssets%" "%emmachinesassets%" /y
copy "%trucking%" "%emmachines%" /y
copy "%truckingAssets%" "%emmachinesassets%" /y
copy "%vehicles%" "%emmachines%" /y
copy "%vehiclesAssets%" "%emmachinesassets%" /y

:: SciFi
::copy "%scifi%" "%emscifi%" /y
::copy "%scifiAssets%" "%emscifiassets%" /y

:: Storage
copy "%shipping%" "%emstorage%" /y
copy "%shippingAssets%" "%emstorageassets%" /y
copy "%stockpiling%" "%emstorage%" /y
copy "%stockpilingAssets%" "%emstorageassets%" /y
::copy "%warehousing%" "%emstorage%" /y
::copy "%warehousingAssets%" "%emstorageassets%" /y

:: Features Pack
copy "%admin%" "%emfeatures%" /y
copy "%commands%" "%emfeatures%" /y
copy "%daily%" "%emfeatures%" /y
copy "%dailyAssets%" "%emfeaturesassets%" /y
copy "%home%" "%emfeatures%" /y
copy "%informatics%" "%emfeatures%" /y
copy "%motd%" "%emfeatures%" /y
copy "%tp%" "%emfeatures%" /y
copy "%warp%" "%emfeatures%" /y
copy "%warpAssets%" "%emfeaturesassets%" /y
copy "%autodoor%" "%emfeatures%" /y
copy "%autodoorAssets%" "%emfeaturesassets%" /y

:: Build Fullpack Bundle
mkdir "%dest%\EM FullPack\Mods\Elixr Mods\"
set fullpack=%dest%\EM FullPack\Mods\Elixr Mods
"C:\Windows\System32\robocopy.exe" "%dest%\EM Artistry\Mods\Elixr Mods" "%fullpack%" /s /e
"C:\Windows\System32\robocopy.exe" "%dest%\EM Building\Mods\Elixr Mods" "%fullpack%" /s /e
::"C:\Windows\System32\robocopy.exe" "%dest%\EM Clothing\Mods\Elixr Mods" "%fullpack%" /s /e
::"C:\Windows\System32\robocopy.exe" "%dest%\EM Energy\Mods\Elixr Mods" "%fullpack%" /s /e
"C:\Windows\System32\robocopy.exe" "%dest%\EM Flags\Mods\Elixr Mods" "%fullpack%" /s /e
::"C:\Windows\System32\robocopy.exe" "%dest%\EM Food\Mods\Elixr Mods" "%fullpack%" /s /e
"C:\Windows\System32\robocopy.exe" "%dest%\EM Games\Mods\Elixr Mods" "%fullpack%" /s /e
"C:\Windows\System32\robocopy.exe" "%dest%\EM Housing\Mods\Elixr Mods" "%fullpack%" /s /e
"C:\Windows\System32\robocopy.exe" "%dest%\EM Machines\Mods\Elixr Mods" "%fullpack%" /s /e
::"C:\Windows\System32\robocopy.exe" "%dest%\EM SciFi\Mods\Elixr Mods" "%fullpack%" /s /e
"C:\Windows\System32\robocopy.exe" "%dest%\EM Storage\Mods\Elixr Mods" "%fullpack%" /s /e
"C:\Windows\System32\robocopy.exe" "%dest%\EM Features Pack\Mods\Elixr Mods" "%fullpack%" /s /e
copy "%framework%" "%fullpack%" /y

echo Move Complete, Now Ready to Begin Compression
@echo off
pause

mkdir "%dir%\bin\Release"
set output=%dir%\bin\Release

:: Build Zips

:: Framework
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Framework.zip" "%dest%\Framework\Mods\"

:: Artistry
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Artistry.zip" "%dest%\EM Artistry\Mods\"

:: Building
:: Individual
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Arches.zip" "%dest%\Arches\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Bricks.zip" "%dest%\Bricks\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Concrete.zip" "%dest%\Concrete\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Greenhousing.zip" "%dest%\Greenhousing\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Roadworking.zip" "%dest%\Roadworking\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Shelving.zip" "%dest%\Shelving\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Tools.zip" "%dest%\Tools\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Windows.zip" "%dest%\Windows\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-BrickArches.zip" "%dest%\Brick Arches\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Blocks.zip" "%dest%\Blocks\Mods\"

:: Bundles
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Building.zip" "%dest%\EM Building\Mods\"

:: Clothing
:: Individual
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Clothes.zip" "%dest%\Clothes\Mods\"

:: Bundles
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Clothing.zip" "%dest%\EM Clothing\Mods\"

:: Energy
:: Individual
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Electronics.zip" "%dest%\Electronics\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Fuel.zip" "%dest%\Fuel\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-GreenEnergy.zip" "%dest%\GreenEnergy\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-NuclearEnergy.zip" "%dest%\NuclearEnergy\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Sensors.zip" "%dest%\Sensors\Mods\"

:: Bundles
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Energy.zip" "%dest%\EM Energy\Mods\"

:: Flags
:: Individual
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Flags.zip" "%dest%\Flags\Mods\"

:: Bundles
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Flags.zip" "%dest%\EM Flags\Mods\"

:: Food
:: Individual
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Farming.zip" "%dest%\Farming\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-FoodSmoking.zip" "%dest%\FoodSmoking\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Hunting.zip" "%dest%\Hunting\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Zymology.zip" "%dest%\Zymology\Mods\"

:: Bundles
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Food.zip" "%dest%\EM Food\Mods\"

:: Games
:: Individual
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-BoardGames.zip" "%dest%\BoardGames\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-BoardTools.zip" "%dest%\BoardTools\Mods\"

:: Bundles
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Games.zip" "%dest%\EM Games\Mods\"

:: Housing
:: Individual
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Doors.zip" "%dest%\Doors\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Furniture.zip" "%dest%\Furniture\Mods\"

:: Bundles
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Housing.zip" "%dest%\EM Housing\Mods\"

:: Machines
:: Individual
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Automation.zip" "%dest%\Automation\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Conveyors.zip" "%dest%\Conveyors\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Production.zip" "%dest%\Production\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Trucking.zip" "%dest%\Trucking\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Vehicles.zip" "%dest%\Vehicles\Mods\"

:: Bundles
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Machines.zip" "%dest%\EM Machines\Mods\"

:: SciFi
:: Individual
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-SciFi.zip" "%dest%\SciFi\Mods\"

:: Bundles
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-SciFi.zip" "%dest%\EM SciFi\Mods\"

:: Storage
:: Individual
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Shipping.zip" "%dest%\Shipping\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Stockpiling.zip" "%dest%\Stockpiling\Mods\"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Warehousing.zip" "%dest%\Warehousing\Mods\"

:: Bundles
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Storage.zip" "%dest%\EM Storage\Mods\"

:: Features Pack
:: Individual
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Admin.zip" "%dest%\Admin\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Commands.zip" "%dest%\Commands\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-APS.zip" "%dest%\APS\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Daily.zip" "%dest%\Daily\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Homes.zip" "%dest%\Home\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Informatics.zip" "%dest%\Informatics\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-MOTD.zip" "%dest%\MOTD\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-TP.zip" "%dest%\TP\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-Warps.zip" "%dest%\Warp\Mods\"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-AutoDoors.zip" "%dest%\AutoDoors\Mods\"

:: Bundles
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-FeaturesPack.zip" "%dest%\EM Features Pack\Mods\"

:: Fullpack
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EM-FullPack.zip" "%dest%\EM Fullpack\Mods\"

pause