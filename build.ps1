#requires -Version 5

[CmdletBinding()]
param (
	[Parameter()]
	[switch]
	$Compress
)

Set-Location (Join-Path $PSScriptRoot 'FurBuilder')

[string]$ArtifactsPath = Join-Path $PSScriptRoot 'artifacts'
[string]$ProjectName = $PSScriptRoot | Split-Path -Leaf
[string]$ArtifactsFile = Join-Path $ArtifactsPath "$ProjectName.zip"

if (Test-Path $ArtifactsPath) { Get-ChildItem $ArtifactsPath -Recurse | Remove-Item -Force }
else { $null = New-Item $ArtifactsPath -ItemType Directory }

if ($PSVersionTable.PSVersion.Major -le 5 -or $IsWindows) { & dotnet publish -r win-x64 -c Release --property:PublishDir=$ArtifactsPath }
elseif ($IsLinux) { & dotnet publish -r linux-x64 -c Release --property:PublishDir=$ArtifactsPath }
elseif ($IsMacOS) { & dotnet publish -r osx-arm64 -c Release --property:PublishDir=$ArtifactsPath }
else { throw 'Unsupported OS.' }

$Files = Get-ChildItem $ArtifactsPath -File
if ($null -eq $Files) { Write-Error 'No binaries found at target path. Compilation may have failed.' }
elseif ($Compress) {
	Compress-Archive $Files $ArtifactsFile -Update
	Remove-Item $Files
}
