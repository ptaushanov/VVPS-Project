dotnet sonarscanner begin /k:"VVPS-BDJ" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="sqp_d707a4d6e5f2106f33d61d5619fde00e0b8790fb"
dotnet build
dotnet sonarscanner end /d:sonar.login="sqp_d707a4d6e5f2106f33d61d5619fde00e0b8790fb"