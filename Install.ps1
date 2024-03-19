# Create Application1 console-app1 image
#docker build -f Corporate.Systems.Applications.Application1\Docker\Dockerfile --force-rm -t console-app1-demo .

# Create Application4 rest-app4 image
docker build -f Corporate.Systems.Applications.Application4\Docker\Dockerfile --force-rm -t rest-app4-demo .

# Create Application5 graphql-app5 image
#docker build -f Corporate.Systems.Applications.Application5\Docker\Dockerfile --force-rm -t graphql-app5-demo .

# Create Master console-master image
#docker build -f Corporate.Systems.Applications.Master\Docker\Dockerfile --force-rm -t console-master-demo .

# Compose bundled containers
#docker compose -f Corporate.Systems.Applications.Application1\Docker\docker-compose.yml -p app1 up -d --build 
docker compose -f Corporate.Systems.Applications.Application4\Docker\docker-compose.yml -p app4 up -d --build
#docker compose -f Corporate.Systems.Applications.Application5\Docker\docker-compose.yml -p app5 up -d --build
#docker compose -f Corporate.Systems.Applications.Master\Docker\docker-compose.yml -p master up -d --build
