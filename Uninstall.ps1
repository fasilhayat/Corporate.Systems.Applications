# STOP AND REMOVE APP1 CONTAINERS
#docker stop app1-app1-1
#docker stop app1-cache-1
#docker rm -f app1-app1-1
#docker rm -f app1-cache-1

# STOP AND REMOVE APP2 CONTAINERS
#docker stop app2-app2-1
#docker stop app2-mongo-1
#docker rm -f app2-app2-1
#docker rm -f app2-mongo-1

# STOP AND REMOVE APP4 CONTAINERS
#docker stop app4-app4-1
#docker rm -f app4-app4-1

# STOP AND REMOVE APP5 CONTAINERS
docker stop app5-app5-1
docker stop app5-cache-1
docker rm -f app5-app5-1
docker rm -f app5-cache-1

# REMOVE IMAGES
#docker rmi console-app1-demo
#docker rmi console-app2-demo
#docker rmi rest-app4-demo
docker rmi graphql-app5-demo