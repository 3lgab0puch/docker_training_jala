#!/bin/sh

docker network create HW1Net

docker volume create --name postgres_data

docker run -d --name postgre_HW1 --network HW1Net -v postgres_data:/var/lib/postgresql/data -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=admin123 -e POSTGRES_DB=SonarQubeDB postgres:latest

docker volume create --name sonarqube_data

docker volume create --name sonarqube_logs

docker volume create --name sonarqube_extensions

docker run -d --name sonarqube_HW1 --network HW1Net -p 9000:9000 -v sonarqube_data:/opt/sonarqube/data -v sonarqube_extensions:/opt/sonarqube/extensions -v sonarqube_logs:/opt/sonarqube/logs -e SONAR_JDBC_URL=jdbc:postgresql://postgre_HW1/SonarQubeDB -e SONAR_JDBC_USERNAME=admin -e SONAR_JDBC_PASSWORD=admin123 sonarqube

docker volume create --name jenkins_home

docker run -d --name jenkins_HW1 --network HW1Net -p 8080:8080 -v jenkins_home:/var/jenkins_home jenkins/jenkins:lts-jdk11

docker volume create --name nexus-data

docker run -d --name nexus_HW1 --network HW1Net -p 8081:8081 -v nexus-data:/nexus-data sonatype/nexus3