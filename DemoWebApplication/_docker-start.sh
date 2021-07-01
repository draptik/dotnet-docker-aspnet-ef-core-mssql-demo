#!/bin/sh

## Manually start "frontend"

## Endpoint on host: http://localhost:5000/weatherforecast

IMAGE_NAME=demowebapp1
CONTAINER_NAME=demo_container

## NOTE: docker/aspnet default internal port is 80
PORT_INTERNAL_DOCKER=80
PORT_EXTERNAL=5000

docker run \
  -it \
  --rm \
  -p ${PORT_EXTERNAL}:${PORT_INTERNAL_DOCKER} \
  --name ${CONTAINER_NAME} \
  ${IMAGE_NAME}