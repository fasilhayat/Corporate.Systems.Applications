Start Windows Powershell or Right-click on the project file and 'Open in Termnial'

C:~\source\repos\Corporate.Systems.Applications\Corporate.Systems.Apllications.Master\Docker\
$ docker-compose -p master up --build

To stop
$ docker-compose stop
$ docker-compose -p down

C:~\source\repos\Corporate.Systems.Applications\XXX\[Dockerfile]
docker build -f Corporate.Systems.Apllications.Master\Dockerfile --force-rm -t console-master-demo .