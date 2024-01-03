Start Windows Powershell or Right-click on the project file and 'Open in Termnial'

C:~\source\repos\Corporate.Systems.Applications\Corporate.Systems.Apllications.Application2\Docker\
$ docker-compose -p app1 up --build

To stop
$ docker-compose stop
$ docker-compose -p down

C:~\source\repos\Corporate.Systems.Applications\XXX\[Dockerfile]
docker build -f Corporate.Systems.Apllications.Application2\Dockerfile --force-rm -t console-app2-demo .