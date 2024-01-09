# Create Application1 console-app1 image and Application2 console-app2 image
docker build -f Corporate.Systems.Applications.Application1\Docker\Dockerfile --force-rm -t console-app1-demo .
docker build -f Corporate.Systems.Applications.Application2\Docker\Dockerfile --force-rm -t console-app2-demo .

# Create Application4 rest-app4 image
docker build -f Corporate.Systems.Applications.Application4\Docker\Dockerfile --force-rm -t rest-app4-demo .

# Compose bundled containers
docker compose -f Corporate.Systems.Applications.Application1\Docker\docker-compose.yml -p app1 up -d --build 
docker compose -f Corporate.Systems.Applications.Application2\Docker\docker-compose.yml -p app2 up -d --build
docker compose -f Corporate.Systems.Applications.Application4\Docker\docker-compose.yml -p app4 up -d --build

