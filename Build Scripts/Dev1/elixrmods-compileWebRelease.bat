@echo off
::Set Path and Directory
set path=%cd%\elixr-mods\bin\9.0
set dir=%cd%\elixr-mods

::Core File Locations, Don't change these
set sbase=%path%\framework\netstandard2.1\em-framework.dll
set sadmin=%path%\Features Pack\netstandard2.1\em-admin.dll
set scommands=%path%\Features Pack\netstandard2.1\em-commands.dll
set sdaily=%path%\Features Pack\netcoreapp3.1\em-daily.dll
set shome=%path%\Features Pack\netstandard2.1\em-home.dll
set sinformatics=%path%\Features Pack\netstandard2.1\em-informatics.dll
set sjokes=%path%\Features Pack\netstandard2.1\em-jokes.dll
set smotd=%path%\Features Pack\netstandard2.1\em-motd.dll
set stp=%path%\Features Pack\netstandard2.1\em-tp.dll
set swarp=%path%\Features Pack\netstandard2.1\em-warp.dll
set sarches=%path%\Deco Pack\netstandard2.1\em-arches.dll
set sdoors=%path%\Deco Pack\netstandard2.1\em-doors.dll
set sarts=%path%\Deco Pack\netstandard2.1\em-artistry.dll
set shomeobjects=%path%\Deco Pack\netstandard2.1\em-homeobjects.dll
set stransport=%path%\Deco Pack\netstandard2.1\em-transportation.dll
set swindows=%path%\Deco Pack\netstandard2.1\em-windows.dll
set sfood=%path%\Deco Pack\netstandard2.1\em-food.dll
set sgames=%path%\Deco Pack\netstandard2.1\em-games.dll
set scontainer=%path%\Conv Pack\netstandard2.1\em-storage.dll
set sscifi=%path%\Conv Pack\netstandard2.1\em-sci-fi.dll
set sgreen=%path%\Conv Pack\netstandard2.1\em-greenenergy.dll
set stail=%path%\Conv Pack\netstandard2.1\em-tailingreprocessing.dll
set spms=%path%\Features Pack\netstandard2.1\em-pms.dll
set schangelog=%dir%\ChangeLog.txt

::Assets File Transfer for Release\Testing Builds
set warpfeatassets=%dir%\Built Unity Assets\FeaturesPack\Assets\EM-Warp.unity3d
set dailyfeatassets=%dir%\Built Unity Assets\FeaturesPack\Assets\EM-Daily.unity3d
set storconvassets=%dir%\Built Unity Assets\ConvPack\Assets\EM-Storage.unity3d
::set machconvassets=%dir%\Built Unity Assets\ConvPack\Assets\EM-Machines.unity3d
set tailconvassets=%dir%\Built Unity Assets\ConvPack\Assets\EM-TailingsReprocessing.unity3d
::set sciconvassets=%dir%\Built Unity Assets\ConvPack\Assets\EM-SciFi.unity3d
set geconvassets=%dir%\Built Unity Assets\ConvPack\Assets\EM-GreenEnergy.unity3d
set archdecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-Arches_Objects.unity3d
set archicondecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-Arches_Icons.unity3d
set doordecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-Doors.unity3d
set fooddecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-Food.unity3d
set gamedecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-Games.unity3d
set homeodecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-HomeObjects_Objects.unity3d
set homeoidecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-HomeObjects_Icons.unity3d
set transdecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-Transportation.unity3d
set windowdecoassets=%dir%\Built Unity Assets\DecoPack\Assets\EM-Windows.unity3d
set artassets=%dir%\Built Unity Assets\Artistry\Assets

::Output Destination
set dest=%dir%\bin\EMWebReleases

::Conv Pack
mkdir "%dest%\GreenEnergy\Elixr Mods\ConvPack"
mkdir "%dest%\GreenEnergy\Elixr Mods\ConvPack\Assets"
set ge=%dest%\GreenEnergy\Elixr Mods\ConvPack
set geasset=%dest%\GreenEnergy\Elixr Mods\ConvPack\Assets

::mkdir "%dest%\Machines\Elixr Mods\ConvPack"
::mkdir "%dest%\Machines\Elixr Mods\ConvPack\Assets"
::set mach=%dest%\Machines\Elixr Mods\ConvPack
::set machasset=%dest%\Machines\Elixr Mods\ConvPack\Assets

mkdir "%dest%\SciFi\Elixr Mods\ConvPack"
mkdir "%dest%\SciFi\Elixr Mods\ConvPack\Assets"
set sci=%dest%\SciFi\Elixr Mods\ConvPack
set sciasset=%dest%\SciFi\Elixr Mods\ConvPack\Assets

mkdir "%dest%\Storage\Elixr Mods\ConvPack"
mkdir "%dest%\Storage\Elixr Mods\ConvPack\Assets"
set storage=%dest%\Storage\Elixr Mods\ConvPack
set storageasset=%dest%\Storage\Elixr Mods\ConvPack\Assets

mkdir "%dest%\Tailings Pack\Elixr Mods\ConvPack"
mkdir "%dest%\Tailings Pack\Elixr Mods\ConvPack\Assets"
set tail=%dest%\Tailings Pack\Elixr Mods\ConvPack
set tailasset=%dest%\Tailings Pack\Elixr Mods\ConvPack\Assets

::Deco Pack
mkdir "%dest%\Arches\Elixr Mods\DecoPack"
mkdir "%dest%\Arches\Elixr Mods\DecoPack\Assets"
set arch=%dest%\Arches\Elixr Mods\DecoPack
set archasset=%dest%\Arches\Elixr Mods\DecoPack

::mkdir "%dest%\Clothes\Elixr Mods\DecoPack"
::mkdir "%dest%\Clothes\Elixr Mods\DecoPack\Assets"
::set cloth=%dest%\Clothes\Elixr Mods\DecoPack
::set clothasset=%dest%\Clothes\Elixr Mods\DecoPack\Assets

mkdir "%dest%\Doors\Elixr Mods\DecoPack"
mkdir "%dest%\Doors\Elixr Mods\DecoPack\Assets"
set door=%dest%\Doors\Elixr Mods\DecoPack
set doorasset=%dest%\Doors\Elixr Mods\DecoPack\Assets

mkdir "%dest%\Food\Elixr Mods\DecoPack"
mkdir "%dest%\Food\Elixr Mods\DecoPack\Assets"
set food=%dest%\Food\Elixr Mods\DecoPack
set foodasset=%dest%\Food\Elixr Mods\DecoPack\Assets

mkdir "%dest%\Games\Elixr Mods\DecoPack"
mkdir "%dest%\Games\Elixr Mods\DecoPack\Assets"
set game=%dest%\Games\Elixr Mods\DecoPack
set gameasset=%dest%\Games\Elixr Mods\DecoPack\Assets

mkdir "%dest%\HomeObjects\Elixr Mods\DecoPack"
mkdir "%dest%\HomeObjects\Elixr Mods\DecoPack\Assets"
set homeo=%dest%\HomeObjects\Elixr Mods\DecoPack
set homeoasset=%dest%\HomeObjects\Elixr Mods\DecoPack\Assets

mkdir "%dest%\Transportation\Elixr Mods\DecoPack"
mkdir "%dest%\Transportation\Elixr Mods\DecoPack\Assets"
set trans=%dest%\Transportation\Elixr Mods\DecoPack
set transasset=%dest%\Transportation\Elixr Mods\DecoPack\Assets

mkdir "%dest%\Windows\Elixr Mods\DecoPack"
mkdir "%dest%\Windows\Elixr Mods\DecoPack\Assets"
set windows=%dest%\Windows\Elixr Mods\DecoPack
set windowsasset=%dest%\Windows\Elixr Mods\DecoPack\Assets

::Features Pack
mkdir "%dest%\Admin\Elixr Mods\FeaturesPack"
set admin=%dest%\Admin\Elixr Mods\FeaturesPack

mkdir "%dest%\APS\Elixr Mods\FeaturesPack"
set aps=%dest%\APS\Elixr Mods\FeaturesPack

mkdir "%dest%\Commands\Elixr Mods\FeaturesPack"
set commands=%dest%\Commands\Elixr Mods\FeaturesPack

mkdir "%dest%\Daily\Elixr Mods\FeaturesPack"
mkdir "%dest%\Daily\Elixr Mods\FeaturesPack\Assets"
set daily=%dest%\Daily\Elixr Mods\FeaturesPack
set dailyasset=%dest%\Daily\Elixr Mods\FeaturesPack\Assets

mkdir "%dest%\Home\Elixr Mods\FeaturesPack"
set home=%dest%\Home\Elixr Mods\FeaturesPack

mkdir "%dest%\Informatics\Elixr Mods\FeaturesPack"
set info=%dest%\Informatics\Elixr Mods\FeaturesPack

mkdir "%dest%\Jokes\Elixr Mods\FeaturesPack"
set joke=%dest%\Jokes\Elixr Mods\FeaturesPack

mkdir "%dest%\MOTD\Elixr Mods\FeaturesPack"
set motd=%dest%\MOTD\Elixr Mods\FeaturesPack

mkdir "%dest%\PMS\Elixr Mods\FeaturesPack"
set pms=%dest%\PMS\Elixr Mods\FeaturesPack

mkdir "%dest%\TP\Elixr Mods\FeaturesPack"
set tp=%dest%\TP\Elixr Mods\FeaturesPack

mkdir "%dest%\Warp\Elixr Mods\FeaturesPack"
mkdir "%dest%\Warp\Elixr Mods\FeaturesPack\Assets"
set warp=%dest%\Warp\Elixr Mods\FeaturesPack
set warpasset=%dest%\Warp\Elixr Mods\FeaturesPack\Assets

::Artistry
mkdir "%dest%\Artistry\Elixr Mods\Artistry"
mkdir "%dest%\Artistry\Elixr Mods\Artistry\Assets"
set art=%dest%\Artistry\Elixr Mods\Artistry
set artasset=%dest%\Artistry\Elixr Mods\Artistry\Assets

::Base
mkdir "%dest%\Framework\Elixr Mods\"
set base=%dest%\Framework\Elixr Mods\

::Extract Files
@echo on
copy "%sbase%" "%base%" /y
copy "%sadmin%" "%admin%" /y
copy "%scommands%" "%commands%" /y
copy "%sdaily%" "%daily%" /y
copy "%shome%" "%home%" /y
copy "%sinformatics%" "%info%" /y
copy "%sjokes%" "%joke%" /y
copy "%smotd%" "%motd%" /y
copy "%stp%" "%tp%" /y
copy "%swarp%" "%warp%" /y
copy "%spms%" "%pms%" /y
copy "%sarches%" "%arch%" /y
copy "%sdoors%" "%door%" /y
copy "%sarts%" "%art%" /y
copy "%shomeobjects%" "%homeo%" /y
copy "%stransport%" "%trans%" /y
copy "%swindows%" "%windows%" /y
copy "%sfood%" "%food%" /y
copy "%sgames%" "%game%" /y
copy "%sscifi%" "%sci%" /y
copy "%scontainer%" "%storage%" /y
copy "%sgreen%" "%ge%" /y
copy "%stail%" "%tail%" /y

::Assets Files Extraction
XCOPY /s/y "%warpfeatassets%" "%warpasset%" /d
XCOPY /s/y "%dailyfeatassets%" "%dailyasset%" /d
XCOPY /s/y "%storconvassets%" "%storageasset%" /d
::XCOPY /s/y "%machconvassets%" "%machasset%" /d
XCOPY /s/y "%tailconvassets%" "%tailasset%" /d
::XCOPY /s/y "%sciconvassets%" "%sciasset%" /d
::XCOPY /s/y "%geconvassets%" "%geasset%" /d
XCOPY /s/y "%archdecoassets%" "%archasset%" /d
XCOPY /s/y "%archicondecoassets%" "%archasset%" /d
XCOPY /s/y "%doordecoassets%" "%doorasset%" /d
XCOPY /s/y "%fooddecoassets%" "%foodasset%" /d
XCOPY /s/y "%gamedecoassets%" "%gameasset%" /d
XCOPY /s/y "%homeodecoassets%" "%homeoasset%" /d
XCOPY /s/y "%homeoidecoassets%" "%homeoasset%" /d
XCOPY /s/y "%transdecoassets%" "%transasset%" /d
XCOPY /s/y "%windowdecoassets%" "%windowsasset%" /d
XCOPY /s/y "%artassets%" "%artasset%" /d

@echo off
@echo on
echo Move Complete, Now Ready to Begin Compression
@echo off

mkdir %dest%\Modules
set output=%dest%\Modules
mkdir %output%\EMFramework
mkdir %output%\Artistry
mkdir %output%\FeaturesPack
mkdir %output%\DecoPack
mkdir %output%\EMFramework
mkdir %output%\FeaturesPack\Admin
mkdir %output%\FeaturesPack\Commands
mkdir %output%\FeaturesPack\APS
mkdir %output%\FeaturesPack\Daily
mkdir %output%\FeaturesPack\Homes
mkdir %output%\FeaturesPack\Informatics
mkdir %output%\FeaturesPack\Jokes
mkdir %output%\FeaturesPack\MOTD
mkdir %output%\FeaturesPack\PMS
mkdir %output%\FeaturesPack\TP
mkdir %output%\FeaturesPack\Warp
mkdir %output%\DecoPack\Arches
mkdir %output%\DecoPack\Doors
mkdir %output%\DecoPack\Food
mkdir %output%\DecoPack\Games
mkdir %output%\DecoPack\HomeO
mkdir %output%\DecoPack\Transportation
mkdir %output%\DecoPack\Windows
mkdir %output%\DecoPack\Clothes
mkdir %output%\ConvPack\GreenEnergy
mkdir %output%\ConvPack\Machines
mkdir %output%\ConvPack\Storage
mkdir %output%\ConvPack\SciFi
mkdir %output%\ConvPack\TailingsPack

::Set Zips - Conv Pack
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\ConvPack\GreenEnergy\EM-GreenEnergy.zip" "%dest%\GreenEnergy\Elixr Mods"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\ConvPack\Machines\EM-Machines.zip" "%dest%\Machines\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\ConvPack\Storage\EM-Storage.zip" "%dest%\Storage\Elixr Mods"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\ConvPack\SciFi\EM-Sci-Fi.zip" "%dest%\Sci-Fi\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\ConvPack\TailingsPack\EM-TailingsPack.zip" "%dest%\Tailings Pack\Elixr Mods"

::Set Zips - Deco Pack
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\Arches\EM-Arches.zip" "%dest%\Arches\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\Doors\EM-Doors.zip" "%dest%\Doors\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\Food\EM-Food.zip" "%dest%\Food\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\Games\EM-Games.zip" "%dest%\Games\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\HomeO\EM-HomeObjects.zip" "%dest%\HomeObjects\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\Transportation\EM-Transportation.zip" "%dest%\Transportation\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\Windows\EM-Windows.zip" "%dest%\Windows\Elixr Mods"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\DecoPack\Clothes\EM-Clothes.zip" "%dest%\Clothes\Elixr Mods"

::Set Zips - Features Pack
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\Admin\EM-Admin.zip" "%dest%\Admin\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\Commands\EM-Commands.zip" "%dest%\Commands\Elixr Mods"
::"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\APS\EM-APS.zip" "%dest%\APS\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\Daily\EM-Daily.zip" "%dest%\Daily\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\Homes\EM-Homes.zip" "%dest%\Home\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\Informatics\EM-Informatics.zip" "%dest%\Informatics\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\Jokes\EM-Jokes.zip" "%dest%\Jokes\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\MOTD\EM-MOTD.zip" "%dest%\MOTD\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\PMS\EM-PMS.zip" "%dest%\PMS\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\TP\EM-TP.zip" "%dest%\TP\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\FeaturesPack\Warps\EM-Warps.zip" "%dest%\Warp\Elixr Mods"

::Set Zips - Others
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\EMFramework\EM-Framework.zip" "%dest%\Framework\Elixr Mods"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%output%\Artistry\EM-Artistry.zip" "%dest%\Artistry\Elixr Mods"

elixrmods-push.bat