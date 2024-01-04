# Create Application1 console-app1 image
docker build -f Corporate.Systems.Apllications.Application1\Dockerfile --force-rm -t console-app1-demo .

# Create Application2 console-app2 image
docker build -f Corporate.Systems.Apllications.Application2\Dockerfile --force-rm -t console-app2-demo .

# Compose bundled containers
docker compose -f Corporate.Systems.Apllications.Application1\Docker\docker-compose.yml -p app1 up -d --build 

# Compose bundled containers
docker compose -f Corporate.Systems.Apllications.Application2\Docker\docker-compose.yml -p app2 up -d --build

