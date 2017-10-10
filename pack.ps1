$ErrorActionPreference = "Stop"
$mainFolder = Resolve-Path (Split-Path -Path $MyInvocation.MyCommand.Definition -Parent)
$nugetExe = "$mainFolder\.nuget\nuget.exe"

Remove-Item $mainFolder\*.nupkg
& "$nugetExe" pack $mainFolder/NMoney/NMoney.csproj -Build -Properties Configuration=Release