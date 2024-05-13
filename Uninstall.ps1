# STOP AND REMOVE APP1 CONTAINERS
docker stop app1-app1-1
docker stop app1-cache-1
docker rm -f app1-app1-1
docker rm -f app1-cache-1

# STOP AND REMOVE APP3 CONTAINERS
docker stop console3-app1-1
docker rm -f console3-app1-1

# STOP AND REMOVE APP4 CONTAINERS
docker stop app4-app4-1
docker rm -f app4-app4-1

# STOP AND REMOVE APP5 CONTAINERS
docker stop app5-app5-1
docker stop app5-cache-1
docker rm -f app5-app5-1
docker rm -f app5-cache-1

# STOP AND REMOVE MASTER CONTAINERs
docker stop master-app-1
docker stop master-mongo-1
docker rm -f master-app-1
docker rm -f master-mongo-1

# REMOVE IMAGES
docker rmi console-app1-demo
docker rmi console-app3-demo
docker rmi rest-app4-demo
docker rmi graphql-app5-demo
docker rmi console-master-demo

# REMOVE ALL UNUSED VOLUMES
docker volume prune -f