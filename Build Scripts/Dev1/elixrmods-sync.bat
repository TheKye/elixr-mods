SET dir=%cd%\elixr-mods

SET PATH=%PATH%;C:\GitLab-Runner\PortableGit\bin
CD %dir%
git pull

RMDIR /Q /S bin
dotnet build

CD ..
elixrmods-compileRelease.bat