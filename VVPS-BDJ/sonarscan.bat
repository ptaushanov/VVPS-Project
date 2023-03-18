dotnet sonarscanner begin /k:"VVPS-BDJ" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="04c292d7809de7252da76a3ff3d5269bf26c4ca4"
dotnet build
dotnet sonarscanner end /d:sonar.login="sqp_04c292d7809de7252da76a3ff3d5269bf26c4ca4"