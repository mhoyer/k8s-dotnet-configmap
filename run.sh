#!/bin/bash

kubectl delete -f k8s.yml
docker build -t k8s-config .
kubectl apply -f k8s.yml
sleep 2
kubectl logs -f pods/k8s-config
